using UnityEngine;

public class TankDestruction : MonoBehaviour
{
    public float threshold = 0.5f; // Kynnysarvo
    public GameObject explosionEffect; // Räjähdysvaikutus

    void Update()
    {
        if (Vector3.Dot(transform.up, Vector3.down) > threshold)
        {
            DestroyTank();
        }
    }

    void DestroyTank()
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }

        Debug.Log("Tank has been destroyed because it flipped over.");
        Destroy(gameObject);
    }
}
