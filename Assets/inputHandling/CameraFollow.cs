using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform ball;        // The ball to follow
    public Vector3 offset;        // The desired offset from the ball
    // public float rotationSpeed = 10f;  // Speed of camera rotation
    // public float verticalSpeed = 10f;  // Speed of vertical camera movement

    private Vector3 currentOffset;

    void Start()
    {
        currentOffset = offset;
    }

    void LateUpdate()
    {
        // Update the camera's position
         Vector3 targetPosition = ball.position + currentOffset;
         // Validate the target position before assigning it to the camera
        if (!float.IsNaN(targetPosition.x) && !float.IsNaN(targetPosition.y) && !float.IsNaN(targetPosition.z))
        {
            transform.position = ball.position + currentOffset;
        }

        // Make the camera look at the ball
        transform.LookAt(ball.position);
    }

    public void RotateLeft(float rotationSpeed)
    {
        // Rotate the camera to the left around the ball
        currentOffset = Quaternion.Euler(0, +rotationSpeed/2 * Time.deltaTime, 0) * currentOffset;
        Debug.Log("Camera rotated left");
    }

    public void RotateRight(float rotationSpeed)
    {
        // Rotate the camera to the right around the ball
        currentOffset = Quaternion.Euler(0, -rotationSpeed/2 * Time.deltaTime, 0) * currentOffset;
        Debug.Log("Camera rotated right");
    }

    public void RotateUp(float verticalSpeed)
    {
        // Move the camera up
        // currentOffset.y += verticalSpeed * Time.deltaTime;
        //rotate Cam UP
        Quaternion rotation = Quaternion.Euler(verticalSpeed*2 * Time.deltaTime, 0, 0);
        currentOffset = rotation * currentOffset;
        Debug.Log("Camera moved up");
    }

    public void RotateDown(float verticalSpeed)
    {
        // Move the camera down
        // currentOffset.y -= verticalSpeed * Time.deltaTime;
                // Rotate the camera down around the ball
        Quaternion rotation = Quaternion.Euler(-verticalSpeed*2 * Time.deltaTime, 0, 0);
        currentOffset = rotation * currentOffset;
        Debug.Log("Camera moved down");
    }
}