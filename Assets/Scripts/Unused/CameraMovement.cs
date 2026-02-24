using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int cameraSensitivity = 200;
    [SerializeField] private bool invertCamera = false;
    
    private float mouseX;
    private float mouseY;
    private float xRotn;
    private float yRotn;

    void Start()
    {
        // Initialize starting position of camera to how it looks in the Scene view
        Vector3 angles = transform.rotation.eulerAngles;
        xRotn = angles.x;
        yRotn = angles.y;

        lockCursor(); // Defined below!

        // Inverts movement so that moving the mouse to the right moves camera angle right, etc.
        if (!invertCamera) cameraSensitivity *= -1;
    }

    void Update()
    {
        // Locks player movement to camera (without using parenting, that gave me some funny issues)
        transform.position = player.transform.position;
        
        // Gets mouse input
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * cameraSensitivity;
        mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * cameraSensitivity;

        xRotn += mouseY;
        yRotn -= mouseX;

        // Prevents camera from rotating more than 90 degrees up and down
        xRotn = Mathf.Clamp(xRotn, -90, 90);

        // Does the rotatey stuff
        transform.rotation = Quaternion.Euler(xRotn, yRotn, 0);

        // Lets you click anywhere normally
        if (Input.GetKeyDown(KeyCode.C)) {
            unlockCursor();
        }

        // Locks your cursor back in the game
        if (Input.GetMouseButtonDown(0)) {
            lockCursor();
        }

        // Quits entire game if pressed (temporary; could be replaced by pause menu, etc.)
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
        
    }

    // Simple functions for hiding or unhiding cursor from view
    // May want to add these to a separate controller script if, for example, a pause menu function uses them as well

    void lockCursor()
    {
        // Locks cursor inside the game, so you can't click outside the window on accident
        Cursor.lockState = CursorLockMode.Locked;

        // Hides cursor
        Cursor.visible = false;
    }

    void unlockCursor()
    {
        // Unlocks cursor
        Cursor.lockState = CursorLockMode.None;

        // Enables cursor visibility
        Cursor.visible = true;
    }
}
