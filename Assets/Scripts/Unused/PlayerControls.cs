using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    // Player movement variables
    [SerializeField] private float movementSpeed = 5;
    private Rigidbody rb;
    private float moveInputX;
    private float moveInputY;
    private Vector3 movement;

    // Camera for referencing its rotation
    [SerializeField] private Camera playerCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Stops the player from falling over due to gravity (capsule temp object)
    }

    void FixedUpdate()
    {
        // Get camera rotations
        Vector3 forward = playerCamera.transform.forward;
        Vector3 right = playerCamera.transform.right;


        // Player movement control (WASD / Arrow keys)
        moveInputX = Input.GetAxis("Horizontal") * -1; // To move in the "away" direction and not towards the camera
        moveInputY = Input.GetAxis("Vertical") * -1;
        movement = new Vector3(moveInputX, 0, moveInputY);
        
        // Adjusts speed and prevents diagonal movement from being faster due to adding forces
        movement = movement.normalized * movementSpeed; 
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
}
