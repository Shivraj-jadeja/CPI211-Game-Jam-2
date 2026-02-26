using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FirstPersonMovement : MonoBehaviour
{
    [Header("Walking")]
    public float speed = 5f;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9f;
    public KeyCode runningKey = KeyCode.LeftShift;

    [Header("Jumping")]
    public bool canJump = true;
    public float jumpPower = 6f;              // impulse jump
    public string jumpButton = "Jump";        // Space by default

    private Rigidbody rb;
    [SerializeField] private bool isJumping = false;

    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogError("[FPM] Missing Rigidbody!");

        // IMPORTANT: do NOT freeze rotation (you said it breaks jumping onto horse)
        // rb.freezeRotation = true;
    }

    void Update()
    {
        if (canJump && Input.GetButtonDown(jumpButton) && !isJumping)
        {
            isJumping = true;
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Use RAW input so it instantly hits -1/0/1 (sprint feels obvious)
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        bool shiftDown = Input.GetKey(runningKey);
        bool hasMoveInput = (Mathf.Abs(h) > 0.01f || Mathf.Abs(v) > 0.01f);

        IsRunning = canRun && shiftDown && hasMoveInput;

        float targetMovingSpeed = IsRunning ? runSpeed : speed;

        // If an override exists, tell us (this is a common reason sprint "does nothing")
        if (speedOverrides.Count > 0)
        {
            float overridden = speedOverrides[speedOverrides.Count - 1]();
            if (Mathf.Abs(overridden - targetMovingSpeed) > 0.01f)
                Debug.Log($"[FPM] Speed override active: {overridden} (was {targetMovingSpeed})");
            targetMovingSpeed = overridden;
        }

        Vector3 localMove = new Vector3(h, 0f, v).normalized * targetMovingSpeed;

        // Apply movement, preserve Y
        Vector3 worldMove = transform.rotation * localMove;
        rb.linearVelocity = new Vector3(worldMove.x, rb.linearVelocity.y, worldMove.z);

        // Small debug when sprinting
        if (IsRunning)
            Debug.Log($"[FPM] SPRINTING vel=({rb.linearVelocity.x:F2},{rb.linearVelocity.z:F2}) speed={targetMovingSpeed}");
    }

    void OnCollisionEnter(Collision col)
    {
        // Land detection like your old project
        Vector3 delta = Vector3.zero;
        List<ContactPoint> contacts = new List<ContactPoint>();
        col.GetContacts(contacts);

        for (int i = 0; i < col.contactCount; i++)
            delta += transform.position - contacts[i].point;

        if (col.contactCount > 0)
            delta /= col.contactCount;

        if (Mathf.Abs(delta.y) > 0.25f)
            isJumping = false;
    }
}