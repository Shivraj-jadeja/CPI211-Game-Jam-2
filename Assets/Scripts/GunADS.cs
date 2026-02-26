using UnityEngine;

public class GunADS : MonoBehaviour
{
    [Header("ADS")]
    public Transform hipPos;
    public Transform adsPos;
    public float adsLerpSpeed = 12f;

    [Header("Recoil")]
    public float recoilBack = 0.05f;       // translation back
    public float recoilUpAngle = 5f;       // rotation in degrees (tip moves up)
    public float recoilRecoverSpeed = 10f; // speed to return to normal

    [Header("Fire Rate")]
    public float fireRate = 0.5f; // seconds between shots

    private bool isAiming = false;
    private Vector3 recoilOffset;
    private Vector3 recoilVelocity;
    private Vector3 currentRotation;
    private Vector3 rotationVelocity;

    private float nextFireTime = 0f;

    private void Update()
    {
        HandleADS();
        HandleRecoil();

        // Optional: detect left click and call Shoot() if you want recoil to trigger automatically
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void HandleADS()
    {
        Transform target = isAiming ? adsPos : hipPos;

        // Lerp position for ADS + translational recoil
        transform.localPosition = Vector3.Lerp(transform.localPosition, target.localPosition + recoilOffset, adsLerpSpeed * Time.deltaTime);

        // Lerp rotation for ADS + rotational recoil
        Quaternion targetRot = target.localRotation * Quaternion.Euler(currentRotation);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRot, adsLerpSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(1)) isAiming = true;
        if (Input.GetMouseButtonUp(1)) isAiming = false;
    }

    private void HandleRecoil()
    {
        // Smoothly decay translation and rotation
        recoilOffset = Vector3.SmoothDamp(recoilOffset, Vector3.zero, ref recoilVelocity, 0.05f);
        currentRotation = Vector3.SmoothDamp(currentRotation, Vector3.zero, ref rotationVelocity, 0.05f);
    }

    public void Shoot()
    {
        // Only apply recoil if fire rate allows
        if (Time.time < nextFireTime) return;

        nextFireTime = Time.time + fireRate;

        ApplyRecoil();
    }

    private void ApplyRecoil()
    {
        // Add back + rotation kick
        recoilOffset += new Vector3(-recoilBack, 0f, 0f);
        currentRotation += new Vector3(recoilUpAngle, 0f, 0f);
    }
}