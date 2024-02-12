using UnityEngine;

public class CrosshairManager : MonoBehaviour
{
    public GameObject crosshair;

    // Update is called once per frame
    void Update()
    {
        // Hide the cursor
        Cursor.visible = false;

        // Get the mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;

        // Set a distance from the camera to the crosshair
        mousePosition.z = 10f;

        // Convert the mouse position from screen space to world space
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Update the crosshair position directly to match the mouse position
        crosshair.transform.position = worldMousePosition;
    }
}
