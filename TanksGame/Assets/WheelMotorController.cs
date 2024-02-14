using UnityEngine;

public class WheelMotorController : MonoBehaviour
{
    public WheelCollider wheelCollider;
    public float motorTorque = 1000f;
    public float brakeTorque = 2000f;

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Debug.Log(verticalInput);

        if (verticalInput > 0)
        {
            // Applying motor torque to move the wheel forward
            wheelCollider.motorTorque = verticalInput * motorTorque;
            wheelCollider.brakeTorque = 0f;
        }
        else if (verticalInput < 0)
        {
            // Applying brake torque to stop the wheel
            wheelCollider.motorTorque = 0f;
            wheelCollider.brakeTorque = Mathf.Abs(verticalInput) * brakeTorque;
        }
        else
        {
            // No input, so no torque applied
            wheelCollider.motorTorque = 0f;
            wheelCollider.brakeTorque = 0f;
        }
    }
}
