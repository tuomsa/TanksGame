using UnityEngine;

public class SteeringTank : MonoBehaviour
{
    public GameObject leftTrack;
    public GameObject rightTrack;
    public float trackSpeed = 300.0f;
    public float maxMoveSpeed = 5.0f;
    public float turnSpeed = 150.0f;
    public float acceleration = 0.5f;
    public float brakeForce = 1.0f; // Lisätty jarrutusvoima
    public float maxUphillAngle = 30.0f;

    private float currentSpeed = 0.0f;

    private void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        UpdateCurrentSpeed(moveInput);

        float rotationAmount = currentSpeed * trackSpeed * Time.deltaTime;
        float moveAmount = currentSpeed * Time.deltaTime;
        float turnAmount = turnInput * turnSpeed * Time.deltaTime;

        if (Mathf.Abs(moveInput) < 0.1f)
        {
            turnAmount *= 2;
        }

        transform.Rotate(0, turnAmount, 0);
        transform.Translate(Vector3.forward * moveAmount);

        RotateTrack(leftTrack, rotationAmount);
        RotateTrack(rightTrack, -rotationAmount);
    }

    private void UpdateCurrentSpeed(float input)
    {
        input = -input; // Kaasu ja jarru ovat nyt oikein päin

        float hillFactor = CalculateHillFactor(input);

        if (input != 0)
        {
            currentSpeed += input * acceleration * hillFactor * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, -maxMoveSpeed, maxMoveSpeed);
        }
        else
        {
            // Sovelletaan jarrutusvoimaa, kun ei ole syötettä
            float brakeSpeed = brakeForce * Time.deltaTime;
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, brakeSpeed);
        }
    }

    private float CalculateHillFactor(float input)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            float angle = Vector3.Angle(hit.normal, Vector3.up);
            if (angle > maxUphillAngle)
            {
                return 0.5f;
            }
            else if (input < 0 && angle < maxUphillAngle)
            {
                return 1.5f;
            }
        }
        return 1.0f;
    }

    private void RotateTrack(GameObject track, float rotationAmount)
    {
        track.transform.Rotate(Vector3.up * rotationAmount, Space.Self);
    }
}
