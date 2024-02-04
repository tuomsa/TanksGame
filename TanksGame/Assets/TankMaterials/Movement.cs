using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    void Update()
    {
        // Get input from arrow keys
        float horizontalInput = -Input.GetAxis("Horizontal");
        float verticalInput = -Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Move the player
        transform.Translate(movement * speed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1")) // Assuming "Fire1" is the left mouse button
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            // Instantiate a bullet at the bullet spawn point
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            // Add force to the bullet to make it move
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                // Assuming you want to shoot in the forward direction of the player
                bulletRigidbody.AddForce(transform.forward * 10f, ForceMode.Impulse);
            }
        }
    }
}
