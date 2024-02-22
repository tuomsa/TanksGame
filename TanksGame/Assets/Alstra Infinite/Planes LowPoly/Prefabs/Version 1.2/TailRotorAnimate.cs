using UnityEngine;

public class TailRotorSpin : MonoBehaviour
{
    public float speed = 1000.0f; // Tail rotorin pyörimisnopeus

    void Update()
    {
        // Pyörittää tail rotorin paikallisen y-akselin (vihreä nuoli) ympäri, 
        // joka vastaa pyörimistä kuin auton rengas maata vasten
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
