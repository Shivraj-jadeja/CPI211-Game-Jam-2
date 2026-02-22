using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private int cameraSensitivity;
    private float rotateHorizontal;
    private float rotateVertical;

    void Start()
    {
        cameraSensitivity = 50;
        rotateHorizontal = 0;
        rotateVertical = 0;
    }

    // UNFINISHED: Camera tilts sideways uncontrollably because it's using a local axis
    void Update()
    {
        rotateHorizontal = Input.GetAxis("Mouse X");
        rotateVertical = Input.GetAxis("Mouse Y");

        // Rotates the camera around its local Right axis
        transform.Rotate(Vector3.right * Time.deltaTime * Input.GetAxis("Mouse Y") * cameraSensitivity);

        // Rotates the camera around its local Up axis
        transform.Rotate(Vector3.up * Time.deltaTime * Input.GetAxis("Mouse X") * cameraSensitivity * -1);
    }
    void FixedUpdate()
    {
        //rotateHorizontal = Input.GetAxis("Mouse X");
        //rotateVertical = Input.GetAxis("Mouse Y");
        //transform.RotateAround(transform.position, -Vector3.up, rotateHorizontal * cameraSensitivity * -1.5f);
        //transform.RotateAround(transform.position, transform.right, rotateVertical * cameraSensitivity * -1);
    }
}
