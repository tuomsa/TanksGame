using UnityEngine;

public class RotorSpin : MonoBehaviour
{
    public float speed = 500.0f; // Py�rimisnopeus, jonka voi s��t�� Unityn editorissa

    void Update()
    {
        // Py�ritt�� roottoria y-akselin ymp�ri
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
