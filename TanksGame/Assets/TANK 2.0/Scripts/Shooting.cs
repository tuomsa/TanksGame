using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;      // The bullet prefab to shoot
    public Transform bulletSpawnPoint;   // The transform from where the bullet is shot
    public float bulletSpeed = 10f;      // The speed of the bullet

    // Update is called once per frame
    void Update()
    {
        // Check if the fire button is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Visualize the bullet's path in the Scene view
        Debug.DrawLine(bulletSpawnPoint.position, bulletSpawnPoint.position + bulletSpawnPoint.forward * 10, Color.green, 1f);

        // Instantiate the bullet prefab at the spawn point's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Get the Rigidbody component from the bullet
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        // If the bullet has a Rigidbody component, add velocity to it in the forward direction
        if (bulletRigidbody != null)
        {
            // Set the velocity of the bullet
            bulletRigidbody.velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
        else
        {
            // If there is no Rigidbody, log a warning message in the console
            Debug.LogWarning("Bullet prefab does not have a Rigidbody component.");
        }
    }
}
