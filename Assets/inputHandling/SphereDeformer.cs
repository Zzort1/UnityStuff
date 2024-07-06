using UnityEngine;

public class SphereDeformer : MonoBehaviour
{
    private MeshFilter meshFilter;
    private Mesh mesh;
    private Vector3[] originalVertices;
    private Vector3[] modifiedVertices;
    private MeshCollider meshCollider;
    private Rigidbody rb;

    public float deformAmount = 0.1f;
    public float deformRadius = 0.5f;
    public float smoothFactor = 0.1f; // Controls the smoothness of the transition
    public float contactThreshold = 0.02f; // Minimum impact required to trigger deformation
    public float maxDeform = 0.1f; // Maximum allowed deformation
    public float restoreSpeed = 0.1f; // Speed at which the ball returns to its original shape

    private bool isDeforming = false;
    private bool isRestoring = false;

    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshCollider = GetComponent<MeshCollider>();
        rb = GetComponent<Rigidbody>();
        mesh = meshFilter.mesh;
        originalVertices = mesh.vertices;
        modifiedVertices = new Vector3[originalVertices.Length];
        ResetMesh();
    }

    private void ResetMesh()
    {
        for (int i = 0; i < originalVertices.Length; i++)
        {
            modifiedVertices[i] = originalVertices[i];
        }
        mesh.vertices = modifiedVertices;
        mesh.RecalculateNormals();
        UpdateCollider();
    }

    private void Update()
    {
        if (isDeforming)
        {
            DeformMesh();
        }
        else if (isRestoring)
        {
            RestoreMesh();
        }
    }

    private void DeformMesh()
    {
        bool meshDeformed = false;

        for (int i = 0; i < originalVertices.Length; i++)
        {
            Vector3 worldVertex = transform.TransformPoint(originalVertices[i]);
            if (Physics.Raycast(worldVertex, -transform.up, out RaycastHit hit, deformRadius))
            {
                float distance = Vector3.Distance(worldVertex, hit.point);
                if (distance < deformRadius && hit.normal.y > contactThreshold)
                {
                    float deformFactor = 1 - (distance / deformRadius);
                    Vector3 deformDirection = transform.up * Mathf.Min(deformAmount * deformFactor, maxDeform);
                    Vector3 targetPosition = originalVertices[i] + transform.InverseTransformDirection(deformDirection);
                    modifiedVertices[i] = Vector3.Lerp(modifiedVertices[i], targetPosition, smoothFactor);
                    meshDeformed = true;
                }
                else
                {
                    modifiedVertices[i] = Vector3.Lerp(modifiedVertices[i], originalVertices[i], restoreSpeed * Time.deltaTime);
                }
            }
            else
            {
                modifiedVertices[i] = Vector3.Lerp(modifiedVertices[i], originalVertices[i], restoreSpeed * Time.deltaTime);
            }
        }

        mesh.vertices = modifiedVertices;
        mesh.RecalculateNormals();

        if (meshDeformed)
        {
            UpdateCollider();
        }
    }

    private void RestoreMesh()
    {
        bool meshRestored = true;

        for (int i = 0; i < modifiedVertices.Length; i++)
        {
            if (modifiedVertices[i] != originalVertices[i])
            {
                modifiedVertices[i] = Vector3.Lerp(modifiedVertices[i], originalVertices[i], restoreSpeed * Time.deltaTime);
                if (Vector3.Distance(modifiedVertices[i], originalVertices[i]) > 0.001f)
                {
                    meshRestored = false;
                }
            }
        }

        mesh.vertices = modifiedVertices;
        mesh.RecalculateNormals();
        UpdateCollider();

        if (meshRestored)
        {
            isRestoring = false;
        }
    }

    private void UpdateCollider()
    {
        meshCollider.sharedMesh = null;
        meshCollider.sharedMesh = mesh;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > contactThreshold)
        {
            isDeforming = true;
            isRestoring = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isDeforming = false;
        isRestoring = true;
    }
}