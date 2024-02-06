using UnityEngine;

public class TankController : MonoBehaviour
{
    public GameObject leftTrack;
    public GameObject rightTrack;
    public float trackSpeed = 300.0f; // Telojen py�rimisnopeus
    public float moveSpeed = 5.0f; // Tankin liikkumisnopeus
    public float turnSpeed = 150.0f; // Tankin k��ntymisnopeus

    private void Update()
    {
        // Saa liikkeen sy�tteen W ja S-n�pp�imilt�.
        float moveInput = -Input.GetAxis("Vertical");

        // Saa k��ntymisen sy�tteen A ja D-n�pp�imilt�.
        float turnInput = Input.GetAxis("Horizontal");

        // Laskee telojen py�rimisnopeuden ja tankin liikkumisnopeuden.
        float rotationAmount = moveInput * trackSpeed * Time.deltaTime;
        float moveAmount = moveInput * moveSpeed * Time.deltaTime;

        // Laskee tankin k��ntymisen m��r�n.
        float turnAmount = turnInput * turnSpeed * Time.deltaTime;

        // K��nt�� tankkia.
        transform.Rotate(0, turnAmount, 0);

        // Liikuttaa tankkia eteenp�in tai taaksep�in.
        transform.Translate(Vector3.forward * moveAmount);

        // Py�ritt�� teloja.
        RotateTrack(leftTrack, rotationAmount);
        RotateTrack(rightTrack, rotationAmount);
    }

    private void RotateTrack(GameObject track, float rotationAmount)
    {
        // Py�ritt�� telaa Y-akselin ymp�ri kuin auton rengasta.
        track.transform.Rotate(Vector3.up * rotationAmount, Space.Self);
    }
}
