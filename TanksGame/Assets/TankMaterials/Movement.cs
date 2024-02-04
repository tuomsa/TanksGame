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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Move the player
        transform.Translate(movement * speed * Time.deltaTime);

        // Rotate player towards the mouse
        RotateTowardsMouse();

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

    void RotateTowardsMouse()
{
    // Get the mouse position in screen coordinates
    Vector3 mousePosition = Input.mousePosition;

    // Convert the mouse position to a ray from the camera
    Ray ray = Camera.main.ScreenPointToRay(mousePosition);

    // Perform a raycast to get the point where the ray intersects with the plane at the player's position
    Plane plane = new Plane(Vector3.up, transform.position);
    float rayDistance;
    if (plane.Raycast(ray, out rayDistance))
    {
        // Get the point where the ray intersects with the plane
        Vector3 targetPoint = ray.GetPoint(rayDistance);

        // Rotate the player towards the target point
        transform.LookAt(new Vector3(targetPoint.x, transform.position.y, targetPoint.z));
    }
}
}
