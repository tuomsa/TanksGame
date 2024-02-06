using UnityEngine;

public class TankController : MonoBehaviour
{
    public GameObject leftTrack;
    public GameObject rightTrack;
    public float trackSpeed = 300.0f; // Telojen pyörimisnopeus
    public float moveSpeed = 5.0f; // Tankin liikkumisnopeus
    public float turnSpeed = 150.0f; // Tankin kääntymisnopeus

    private void Update()
    {
        // Saa liikkeen syötteen W ja S-näppäimiltä.
        float moveInput = -Input.GetAxis("Vertical");

        // Saa kääntymisen syötteen A ja D-näppäimiltä.
        float turnInput = Input.GetAxis("Horizontal");

        // Laskee telojen pyörimisnopeuden ja tankin liikkumisnopeuden.
        float rotationAmount = moveInput * trackSpeed * Time.deltaTime;
        float moveAmount = moveInput * moveSpeed * Time.deltaTime;

        // Laskee tankin kääntymisen määrän.
        float turnAmount = turnInput * turnSpeed * Time.deltaTime;

        // Kääntää tankkia.
        transform.Rotate(0, turnAmount, 0);

        // Liikuttaa tankkia eteenpäin tai taaksepäin.
        transform.Translate(Vector3.forward * moveAmount);

        // Pyörittää teloja.
        RotateTrack(leftTrack, rotationAmount);
        RotateTrack(rightTrack, rotationAmount);
    }

    private void RotateTrack(GameObject track, float rotationAmount)
    {
        // Pyörittää telaa Y-akselin ympäri kuin auton rengasta.
        track.transform.Rotate(Vector3.up * rotationAmount, Space.Self);
    }
}
