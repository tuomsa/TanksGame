using UnityEngine;

public class TankDestruction : MonoBehaviour
{
    public float threshold = 0.5f; // Kynnysarvo, joka m��ritt��, mik� katsotaan "yl�salaisin" olemiseksi

    void Update()
    {
        // Tarkista onko tankin y-akselin yl�sp�in osoittava vektori osoittaa alasp�in.
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

        // T�ss� voit lis�t� muita toimintoja, kuten r�j�hdysanimaatiota tai pisteiden laskua.
    }
}
