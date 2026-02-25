using System.Threading;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int shotSpeed = 50;
    private GameObject bullet;
    // Where the bullet spawns "within" the gun
    // May need to be adjusted to appear to come out of the barrel of the gun when proper asset is added
    [SerializeField] private Vector3 bulletDisplacement = new Vector3(0, 0, -0.5f);

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse button clicked");
            bullet = Instantiate(bulletPrefab, transform.position + bulletDisplacement, transform.rotation); // Change position and rotation later
            bullet.GetComponent<Rigidbody>().AddForce(-transform.forward * shotSpeed, ForceMode.Impulse);
        }
    }
}
