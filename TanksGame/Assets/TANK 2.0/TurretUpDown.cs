using UnityEngine;

public class TurretController2 : MonoBehaviour
{
    public Transform barrel; // Assign your barrel transform in the inspector
    public float maxUpRotation = 20.0f; // Maximum elevation angle
    public float maxDownRotation = -5.0f; // Maximum depression angle
    public float rotationSpeed = 5.0f; // Speed at which the barrel rotates

    private float currentRotation = 0.0f;

    void Update()
    {
        // Get the mouse input
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        Debug.Log("Mouse Y Input: " + mouseY); // Lisätty debug-viesti

        // Calculate the new rotation as a single float representing degrees
        currentRotation = Mathf.Clamp(currentRotation - mouseY, maxDownRotation, maxUpRotation);
        Debug.Log("Current Rotation: " + currentRotation); // Lisätty debug-viesti

        // Apply the rotation to the barrel
        barrel.localEulerAngles = new Vector3(currentRotation, barrel.localEulerAngles.y, barrel.localEulerAngles.z);
    }

}
