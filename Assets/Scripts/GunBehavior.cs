using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletPosition; // Where bullets spawn
    [SerializeField] private int shotSpeed = 10;

    [Header("Fire Rate")]
    [SerializeField] private float fireRate = 0.5f; // Time between shots in seconds

    private float nextFireTime = 0f;

    void Update()
    {
        // Check if left mouse button is pressed AND cooldown has passed
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        nextFireTime = Time.time + fireRate;

        GameObject bullet = Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(-transform.forward * shotSpeed, ForceMode.Impulse);

        FindAnyObjectByType<AudioManager>().Play("Shoot");
        Debug.Log("Shot fired!");
    }
}