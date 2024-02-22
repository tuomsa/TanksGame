using UnityEngine;

public class RotorSpin : MonoBehaviour
{
    public float speed = 500.0f; // Pyörimisnopeus, jonka voi säätää Unityn editorissa

    void Update()
    {
        // Pyörittää roottoria y-akselin ympäri
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
