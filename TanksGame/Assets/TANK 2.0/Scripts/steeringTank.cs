using UnityEngine;

public class SteeringTank : MonoBehaviour
{
    public float trackSpeed = 300.0f;
    public float maxMoveSpeed = 5.0f;
    public float turnSpeed = 150.0f;
    public float acceleration = 0.5f;
    public float brakeForce = 1.0f;

    private float currentSpeed = 0.0f;

    private void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        UpdateCurrentSpeed(moveInput);

        float moveAmount = currentSpeed * Time.deltaTime;
        float turnAmount = turnInput * turnSpeed * Time.deltaTime;

        if (Mathf.Abs(moveInput) < 0.1f)
        {
            turnAmount *= 2;
        }

        transform.Rotate(0, turnAmount, 0);
        transform.Translate(Vector3.forward * moveAmount);
    }

    private void UpdateCurrentSpeed(float input)
    {
        input = -input;

        if (input != 0)
        {
            currentSpeed += input * acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, -maxMoveSpeed, maxMoveSpeed);
        }
        else
        {
            float brakeSpeed = brakeForce * Time.deltaTime;
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, brakeSpeed);
        }
    }
}
