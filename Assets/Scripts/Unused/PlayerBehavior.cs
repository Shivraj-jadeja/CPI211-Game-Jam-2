using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * moveX + transform.up * moveY;
        
    }

    // Extra equations
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
