using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Change "Fire1" to the input you want to use for shooting
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the bullet prefab at the spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Get the rigidbody component of the bullet
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        // If the bullet has a rigidbody, shoot it
        if (bulletRigidbody != null)
        {
            // Apply force to the bullet in the forward direction of the spawn point
            bulletRigidbody.velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
        else
        {
            Debug.LogWarning("Bullet prefab does not have a Rigidbody component.");
        }
    }
}
