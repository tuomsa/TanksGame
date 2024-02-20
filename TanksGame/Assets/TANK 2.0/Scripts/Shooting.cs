using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;

    // Partikkelisysteemien viittaukset
    public GameObject muzzleFlashEffect;
    public GameObject cannonFireEffect;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.DrawLine(bulletSpawnPoint.position, bulletSpawnPoint.position + bulletSpawnPoint.forward * 10, Color.green, 1f);

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = bulletSpawnPoint.forward * bulletSpeed;

            // Aktivoi partikkeliefektit
            if (muzzleFlashEffect != null)
            {
                Instantiate(muzzleFlashEffect, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            }
            if (cannonFireEffect != null)
            {
                Instantiate(cannonFireEffect, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            }
        }
        else
        {
            Debug.LogWarning("Bullet prefab does not have a Rigidbody component.");
        }
    }
}
