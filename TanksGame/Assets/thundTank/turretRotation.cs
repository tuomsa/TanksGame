using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    public float rotationSpeed = 100.0f; // Py�rimisnopeuden s��t�

    void Update()
    {
        // Tarkista hiiren liike x-akselilla
        float mouseX = Input.GetAxis("Mouse X");

        // Py�rit� tornia Z-akselin suuntaisesti hiiren liikkeen perusteella
        transform.Rotate(0, 0, mouseX * rotationSpeed * Time.deltaTime);
    }
}
