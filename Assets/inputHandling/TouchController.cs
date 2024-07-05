using UnityEngine;
using UnityEngine.InputSystem;

public class TouchController : MonoBehaviour
{
    public Camera mainCamera;
    public CameraFollow cameraFollow;
    public float maxPushForce = 3.0f;
    public float maxRotationSpeed = 150f;

    public float maxVerticalSpeed = 80f;
    private TouchInputActions touchInputActions;
    private InputAction touchPositionAction;
    private InputAction touchPressureAction;

        private bool isTouching;

    private void Awake()
    {
        touchInputActions = new TouchInputActions();
    }

    private void OnEnable()
    {
        touchPositionAction = touchInputActions.Touch.PrimaryTouch;
        touchPressureAction = touchInputActions.Touch.PrimaryTouchPressure;
        touchPositionAction.Enable();
        touchPressureAction.Enable();
        
        touchPositionAction.performed += OnTouchPerformed;
        touchPositionAction.canceled += OnTouchCanceled;
        touchPressureAction.performed += OnTouchPerformed;
        touchPressureAction.canceled += OnTouchCanceled;
    }

    private void OnDisable()
    {
        touchPositionAction.Disable();
        touchPressureAction.Disable();

        touchPositionAction.performed -= OnTouchPerformed;
        touchPositionAction.canceled -= OnTouchCanceled;
        touchPressureAction.performed -= OnTouchPerformed;
        touchPressureAction.canceled -= OnTouchCanceled;
    }

    private void OnTouchPerformed(InputAction.CallbackContext context)
    {
        isTouching = true;
         Debug.Log("Touch started");
    }

    private void OnTouchCanceled(InputAction.CallbackContext context)
    {
        isTouching = false;
        Debug.Log("Touch canceled");

    }

    private void Update()
    {
 
       if (isTouching) {
            Vector2 touchPosition = touchPositionAction.ReadValue<Vector2>();
            float touchPressure = touchPressureAction.ReadValue<float>();
            Debug.Log($"Touch position: {touchPosition}, Touch pressure: {touchPressure}");

            if (touchPressure == 0)
            {
                touchPressure = 0.3f; // Apply a default pressure value if touch pressure is zero
            }

            Ray ray = mainCamera.ScreenPointToRay(touchPosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Ball"))
                {
                    Debug.Log("Touched the ball!");

                    Rigidbody ballRigidbody = hit.collider.GetComponent<Rigidbody>();
                    if (ballRigidbody != null && touchPositionAction.triggered)
                    {
                        Vector3 touchPoint = hit.point;
                        Vector3 pushDirection = ballRigidbody.position - touchPoint;
                        pushDirection.y = 0; // Keep the force horizontal
                        pushDirection.Normalize();
                        float scaledForce = touchPressure * maxPushForce;
                        ballRigidbody.AddForce(pushDirection * scaledForce, ForceMode.Impulse);

                        Debug.Log($"Applied force: {scaledForce} in direction: {pushDirection}");
                    }
                }
                else
                {
                    Debug.Log("Touched something else: " + hit.collider.name);
    // Calculate the screen dimensions and center
                    float screenHeight = Screen.height;
                    float screenWidth = Screen.width;
                    float middleX = screenWidth / 2;
                    float middleY = screenHeight / 2;

                    // Calculate distances from the center
                    float horizontalDistance = (touchPosition.x - middleX) / middleX;
                    float verticalDistance = (touchPosition.y - middleY) / middleY;

                    // Calculate rotation speeds based on distances
                    float horizontalRotationSpeed = horizontalDistance * maxRotationSpeed;
                    float verticalRotationSpeed = verticalDistance * maxVerticalSpeed;

                    // Determine rotation direction
                    if (Mathf.Abs(horizontalDistance) > Mathf.Abs(verticalDistance))
                    {
                        // Rotate left or right
                        if (horizontalDistance < 0)
                        {
                            Debug.Log("Rotating camera left with speed: " + Mathf.Abs(horizontalRotationSpeed));
                            cameraFollow.RotateLeft(Mathf.Abs(horizontalRotationSpeed));
                        }
                        else
                        {
                            Debug.Log("Rotating camera right with speed: " + Mathf.Abs(horizontalRotationSpeed));
                            cameraFollow.RotateRight(Mathf.Abs(horizontalRotationSpeed));
                        }
                    }
                    else
                    {
                        // Rotate up or down
                        if (verticalDistance < 0)
                        {
                            Debug.Log("Rotating camera down with speed: " + Mathf.Abs(verticalRotationSpeed));
                            cameraFollow.RotateDown(Mathf.Abs(verticalRotationSpeed));
                        }
                        else
                        {
                            Debug.Log("Rotating camera up with speed: " + Mathf.Abs(verticalRotationSpeed));
                            cameraFollow.RotateUp(Mathf.Abs(verticalRotationSpeed));
                        }
                    }
                }
            }
            else
            {
   // Calculate the screen dimensions and center
                float screenHeight = Screen.height;
                float screenWidth = Screen.width;
                float middleX = screenWidth / 2;
                float middleY = screenHeight / 2;

                // Calculate distances from the center
                float horizontalDistance = (touchPosition.x - middleX) / middleX;
                float verticalDistance = (touchPosition.y - middleY) / middleY;

                // Calculate rotation speeds based on distances
                float horizontalRotationSpeed = horizontalDistance * maxRotationSpeed;
                float verticalRotationSpeed = verticalDistance * maxVerticalSpeed;

                // Determine rotation direction
                // if (Mathf.Abs(horizontalDistance) > Mathf.Abs(verticalDistance))
                // {
                    // Rotate left or right
                    if (horizontalDistance < 0)
                    {
                        Debug.Log("Rotating camera left with speed: " + Mathf.Abs(horizontalRotationSpeed));
                        cameraFollow.RotateLeft(Mathf.Abs(horizontalRotationSpeed));
                    }
                    else
                    {
                        Debug.Log("Rotating camera right with speed: " + Mathf.Abs(horizontalRotationSpeed));
                        cameraFollow.RotateRight(Mathf.Abs(horizontalRotationSpeed));
                    }
                // }
                // else
                // {
                    // Rotate up or down
                    if (verticalDistance < 0)
                    {
                        Debug.Log("Rotating camera down with speed: " + Mathf.Abs(verticalRotationSpeed));
                        cameraFollow.RotateDown(Mathf.Abs(verticalRotationSpeed));
                    }
                    else
                    {
                        Debug.Log("Rotating camera up with speed: " + Mathf.Abs(verticalRotationSpeed));
                        cameraFollow.RotateUp(Mathf.Abs(verticalRotationSpeed));
                    }
                // }
            }
         } else {
               cameraFollow.RotateUp(0f);
               cameraFollow.RotateDown(0f);
               cameraFollow.RotateLeft(0f);
               cameraFollow.RotateRight(0f); 
         }


    }
}