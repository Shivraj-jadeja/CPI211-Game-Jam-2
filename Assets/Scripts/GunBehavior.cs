using System.Threading;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletPosition; // Child object in Hierarchy inside gun's barrel; where bullets spawn from
    [SerializeField] private int shotSpeed = 10;
    private GameObject bullet;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse button clicked");
            bullet = Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(-transform.forward * shotSpeed, ForceMode.Impulse);

            FindAnyObjectByType<AudioManager>().Play("Shoot");
        }
    }
}
