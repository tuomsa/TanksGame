using UnityEngine;

public class BarrelController : MonoBehaviour
{
    // Speed of barrel rotation
    public float rotationSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        // Get the current mouse position
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position from screen space to world space
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y));

        // Calculate the direction from the barrel to the mouse position
        Vector3 directionToMouse = mouseWorldPosition - transform.position;
        directionToMouse.x = 0f; // Assuming the barrel rotates only around the x-axis

        // Calculate the rotation angle towards the mouse position
        Quaternion targetRotation = Quaternion.LookRotation(directionToMouse);

        // Smoothly rotate the barrel towards the mouse position
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
