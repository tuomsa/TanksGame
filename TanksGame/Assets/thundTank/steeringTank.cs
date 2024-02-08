using UnityEngine;

public class TankController : MonoBehaviour
{
    public GameObject leftTrack;
    public GameObject rightTrack;
    public float trackSpeed = 300.0f;
    public float maxMoveSpeed = 5.0f;
    public float turnSpeed = 150.0f;
    public float acceleration = 0.5f; // Lisätty kiihtyvyys
    public float maxUphillAngle = 30.0f; // Maksimi kulma, jonka jälkeen teho laskee

    private float currentSpeed = 0.0f; // Nykyinen nopeus

    private void Update()
    {
        float moveInput = -Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        // Päivitä nykyinen nopeus kiihtyvyyden perusteella
        UpdateCurrentSpeed(moveInput);

        float rotationAmount = currentSpeed * trackSpeed * Time.deltaTime;
        float moveAmount = currentSpeed * Time.deltaTime;
        float turnAmount = turnInput * turnSpeed * Time.deltaTime;

        transform.Rotate(0, turnAmount, 0);
        transform.Translate(Vector3.forward * moveAmount);

        RotateTrack(leftTrack, rotationAmount);
        RotateTrack(rightTrack, rotationAmount);
    }

    private void UpdateCurrentSpeed(float input)
    {
        if (input != 0)
        {
            // Lisää nopeutta kiihtyvyyden mukaan, mutta ei yli maksiminopeuden
            currentSpeed += input * acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, -maxMoveSpeed, maxMoveSpeed);

            // Tarkista kulma ja vähennä tehoa tarvittaessa
            if (IsUphill() && Mathf.Abs(currentSpeed) > maxMoveSpeed / 2)
            {
                currentSpeed *= 0.5f; // Voiman väheneminen ylämäessä
            }
        }
        else
        {
            // Hidastaa tankkia, jos ei ole syötettä
            currentSpeed = 0;
        }
    }

    private bool IsUphill()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            float angle = Vector3.Angle(hit.normal, Vector3.up);
            return angle > maxUphillAngle;
        }
        return false;
    }

    private void RotateTrack(GameObject track, float rotationAmount)
    {
        track.transform.Rotate(Vector3.up * rotationAmount, Space.Self);
    }
}
