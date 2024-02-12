using UnityEngine;

public class CannonFire : MonoBehaviour
{
    public Transform barrelEnd; // Aseta t‰m‰ Unity-editorissa osoittamaan piipun p‰‰ty‰
    public GameObject projectilePrefab; // Ammuksen prefab, jonka haluat ampua

    void Update()
    {
        // Tarkista, onko pelaaja painanut ampumisn‰pp‰int‰ (esim. hiiren vasenta nappia)
        if (Input.GetButtonDown("Fire1"))
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        // Instansioi ammus piipun p‰‰st‰ ja anna sille suunta
        GameObject projectile = Instantiate(projectilePrefab, barrelEnd.position, barrelEnd.rotation);
        // Bullet-skripti hoitaa voiman lis‰‰misen ja tuhoamisen, joten ei tarvitse tehd‰ mit‰‰n muuta t‰ss‰
    }
}
