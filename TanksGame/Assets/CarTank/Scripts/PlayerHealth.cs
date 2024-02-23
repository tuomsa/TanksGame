using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 1000;
    private int currentHealth;
    public Slider healthSlider;
    public TextMeshProUGUI healthText; 

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        UpdateHealthText(); 
    }

    void UpdateHealthText()
    {
        if (healthText != null)
            healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        UpdateHealthText(); 

        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead!");
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        
        healthSlider.value = currentHealth;
        UpdateHealthText(); 
    }

    //  OnTriggerEnter-metodi, joka kutsuu TakeDamage-metodia kun pelaaja osuu vihollisen luotiin
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            // Ota vahinkoa vihollisen luodista
            int damageAmount = 10; // Voit säätää vahingon määrää tarpeen mukaan
            TakeDamage(damageAmount);
        }
    }
}
