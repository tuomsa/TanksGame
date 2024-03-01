using UnityEngine;


public class Crosshair : MonoBehaviour
{
    public GameObject crosshair;
    public float sensitivity = 1f; // Sensitivity for mouse movement

    private Vector3 lastMousePosition;

    void Start()
    {  
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        // Hide the cursor
        Cursor.visible = false;

        // Set the initial last mouse position to the center of the screen
        lastMousePosition = new Vector3(Screen.width / 2f, Screen.height / 2f, 0); 
    }

    void Update()
    {
        // Get the mouse movement since the last frame
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Add mouse movement to the last mouse position
        lastMousePosition += new Vector3(mouseX, mouseY, 0);

        // Set the cursor visibility and lock state
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Set a distance from the camera to the crosshair
        Vector3 mousePosition = new Vector3(Screen.width / 2f, Screen.height / 2f, 10f);

        // Convert the center of the screen to world space
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Update the crosshair position directly to match the mouse position
        crosshair.transform.position = worldMousePosition;
    }
}
