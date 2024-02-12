using UnityEngine;

public class TurretController2 : MonoBehaviour
{
    public Transform barrel; // Assign your barrel transform in the inspector
    public float maxElevationAngle = 20.0f; // Maximum angle you can shoot upwards
    public float maxDepressionAngle = 5.0f; // Maximum angle you can shoot downwards
    public float rotationSpeed = 5.0f; // Speed at which the barrel rotates

    private float currentRotation = 0.0f;

    void Update()
    {
        // Get the mouse input
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        // Adjust current rotation based on mouse input. Invert the mouseY by multiplying by -1 if necessary
        currentRotation += mouseY;

        // Clamp the current rotation to the max elevation and depression angles
        currentRotation = Mathf.Clamp(currentRotation, -maxDepressionAngle, maxElevationAngle);

        // Apply the rotation to the barrel around its local X axis
        barrel.localEulerAngles = new Vector3(-currentRotation, barrel.localEulerAngles.y, barrel.localEulerAngles.z);
    }
}
