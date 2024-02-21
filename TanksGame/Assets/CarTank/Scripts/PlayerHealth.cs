using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 1000;
    private int currentHealth;
    public Slider healthSlider;
    public TextMeshProUGUI healthText; // Lis�tty viite Text-komponenttiin

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        UpdateHealthText(); // P�ivit� teksti alussa
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
        UpdateHealthText(); // P�ivit� teksti vahingon ottamisen j�lkeen

        if (currentHealth <= 0)
        {
            // Pelaaja on kuollut.
            Debug.Log("Player is dead!");
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        healthSlider.value = currentHealth;
        UpdateHealthText(); // P�ivit� teksti parantumisen j�lkeen
    }
}
