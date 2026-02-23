using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    // Player movement variables
    [SerializeField] private float movementSpeed = 5;
    private Rigidbody rb;
    private float moveInputX;
    private float moveInputY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player movement control (WASD / Arrow keys)
        moveInputX = Input.GetAxis("Horizontal") * -1; // To move in the "away" direction and not towards the camera
        moveInputY = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // Moves player object based on control values (0.1f because movement speed scale is very large)
        rb.linearVelocity = new Vector3(rb.linearVelocity.x + moveInputX * movementSpeed * 0.1f,
            rb.linearVelocity.y,
            rb.linearVelocity.z + moveInputY * movementSpeed * 0.1f);
    }
}
