using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public int power = 5;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * power, ForceMode.Impulse);
        Destroy(gameObject, 5);

    }

    void OnCollisionEnter(Collision collision)
    {
        print("collision");
    }
  
}
