using UnityEngine;

public class TankDestruction : MonoBehaviour
{
    public float threshold = 0.5f; // Kynnysarvo, joka määrittää, mikä katsotaan "ylösalaisin" olemiseksi

    void Update()
    {
        // Tarkista onko tankin y-akselin ylöspäin osoittava vektori osoittaa alaspäin.
        if (Vector3.Dot(transform.up, Vector3.down) > threshold)
        {
            DestroyTank();
        }
    }

    void DestroyTank()
    {
        // Tuhotaan tankki ja tulostetaan viesti konsoliin.
        Debug.Log("Tank has been destroyed because it flipped over.");
        Destroy(gameObject);

        // Tässä voit lisätä muita toimintoja, kuten räjähdysanimaatiota tai pisteiden laskua.
    }
}
