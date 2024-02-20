using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Viittaus r‰j‰hdys- tai tuhoutumisefektiin.
    public GameObject explosionEffect;

    void OnTriggerEnter(Collider other)
    {
        // Luo r‰j‰hdys tai tuhoutumisefekti.
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }

        // Tuhotaan ammus.
        Destroy(gameObject);

        // T‰ss‰ voit lis‰t‰ lis‰logiikkaa, esimerkiksi vahingoittamaan osuman saanutta kohdetta.
        // Esimerkiksi: if (other.CompareTag("Enemy")) { // Vahingoita vihollista }
    }

    // Lis‰‰ tarvittaessa muita metodeja, esimerkiksi ammuksen liikuttamiseen tai muuhun logiikkaan.
}
