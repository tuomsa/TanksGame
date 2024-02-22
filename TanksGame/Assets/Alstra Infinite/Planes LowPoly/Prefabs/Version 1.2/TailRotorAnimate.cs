using UnityEngine;

public class TailRotorSpin : MonoBehaviour
{
    public float speed = 1000.0f; // Tail rotorin py�rimisnopeus

    void Update()
    {
        // Py�ritt�� tail rotorin paikallisen y-akselin (vihre� nuoli) ymp�ri, 
        // joka vastaa py�rimist� kuin auton rengas maata vasten
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
