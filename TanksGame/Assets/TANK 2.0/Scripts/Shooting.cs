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
                var muzzleFlashInstance = Instantiate(muzzleFlashEffect, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                var muzzleFlashParticleSystem = muzzleFlashInstance.GetComponent<ParticleSystem>();
                if (muzzleFlashParticleSystem != null)
                {
                    muzzleFlashParticleSystem.Play();
                }
            }
            if (cannonFireEffect != null)
            {
                var cannonFireInstance = Instantiate(cannonFireEffect, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                var cannonFireParticleSystem = cannonFireInstance.GetComponent<ParticleSystem>();
                if (cannonFireParticleSystem != null)
                {
                    cannonFireParticleSystem.Play();
                }
            }
        }
        else
        {
            Debug.LogWarning("Bullet prefab does not have a Rigidbody component.");
        }
    }

}
