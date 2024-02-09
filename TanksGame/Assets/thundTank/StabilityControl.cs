using UnityEngine;

public class TankStabilizer : MonoBehaviour
{
    public float stability = 0.3f;
    public float stabilitySpeed = 2.0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Hanki paikallinen kallistuskulma ja käännä se vektoriksi.
        Vector3 predictedUp = Quaternion.AngleAxis(
            rb.angularVelocity.magnitude * Mathf.Rad2Deg * stability / stabilitySpeed,
            rb.angularVelocity
        ) * transform.up;

        // Lasketaan vääntömomentti, joka palauttaisi objektin pystyasentoon.
        Vector3 torqueVector = Vector3.Cross(predictedUp, Vector3.up);
        rb.AddTorque(torqueVector * stabilitySpeed * stabilitySpeed);
    }
}
