using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;     // Maximum health the player can have
    public int currentHealth;      // Player's current health
    public Slider healthBar;       // Health bar UI element
    public Text healthText;        // Health display text (optional)

    private void Start()
    {
        currentHealth = maxHealth; // Initialize health
        UpdateHealthUI();
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateHealthUI();

        if (currentHealth == 0)
        {
            OnDeath();
        }
    }

    // Method to heal the player
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateHealthUI();
    }

    // Update the health UI
    private void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth; // Update the slider
        }

        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth + "/" + maxHealth; // Update the text
        }
    }

    // Handle player death
    private void OnDeath()
    {
        Debug.Log("Player has died!");
        // Add logic for death (e.g., game over screen, respawn, etc.)
    }
}
