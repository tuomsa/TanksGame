using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100; // Initial health of the enemy
    private int currentHealth; // Current health of the enemy

    public GameObject playerBulletPrefab; // Drag the player bullet prefab here
    public int damageTaken = 10; // Amount of damage taken from each player bullet hit

    void Start()
    {
        currentHealth = startingHealth; // Initialize current health
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            TakeDamage(damageTaken); // Enemy takes specified damage when hit by a player bullet
            Destroy(other.gameObject); // Destroy the bullet
        }
    }

    // Method to take damage
    public void TakeDamage(int damageAmount)
    {
        // Reduce current health by damage amount
        currentHealth -= damageAmount;
        Debug.Log("Enemy takes " + damageTaken + " damage");

        // Check if the enemy is defeated
        if (currentHealth <= 0)
        {
            Defeated(); // Call Defeated method if health drops to or below zero
        }
    }

    // Method to handle defeat
    void Defeated()
    {
        Debug.Log("Enemy defeated!");
        Destroy(gameObject); // Destroy the enemy GameObject
    }
}
