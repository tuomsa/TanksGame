using UnityEngine;

public class TurretController : MonoBehaviour
{
    // Speed of turret rotation
    public float rotationSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        // Get the current mouse position
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position from screen space to world space
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y));

        // Calculate the direction from the turret to the mouse position
        Vector3 directionToMouse = mouseWorldPosition - transform.position;
        directionToMouse.y = 0f; // Assuming the turret rotates only around the y-axis

        // Calculate the rotation angle towards the mouse position
        Quaternion targetRotation = Quaternion.LookRotation(directionToMouse);

        // Smoothly rotate the turret towards the mouse position
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
