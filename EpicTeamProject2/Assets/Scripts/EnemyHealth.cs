using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;  // Starting health of the enemy
    private EnemyRagdollControl ragdollControl;  // Reference to the EnemyRagdollControl script
    private float damageTaken;  // Amount of damage to be subtracted from health
    public int goldReward = 25;
    private bool overFlow = true;

    void Start()
    {
        // Get the EnemyRagdollControl component from the same GameObject
        ragdollControl = GetComponent<EnemyRagdollControl>();
    }

    // Method to apply damage to the enemy
    public void TakeDamage(float damage)
    {
        
        health -= damage;  // Subtract the damage from the health

        // Check if health drops below zero
        if (health <= 0 && overFlow == true)
        {
            // Trigger the ragdoll effect when health goes below zero
            if (ragdollControl != null)
            {
                ragdollControl.SetRagdollState(true);  // Activate ragdoll
            }

            if (GoldManager.Instance != null)
            {
                GoldManager.Instance.AddGold(goldReward);
            }

            // Optionally, you can play death animation, trigger event, etc.
            Debug.Log("Enemy died!");

            overFlow = false;

            // Start the coroutine to make the enemy lie down for 5 seconds before disappearing
            StartCoroutine(HandleEnemyDeath());
        }
    }

    // IEnumerator for handling the enemy's death process
    private IEnumerator HandleEnemyDeath()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // After 5 seconds, destroy or deactivate the enemy
        Destroy(gameObject);  // This will remove the enemy from the scene
    }

    // Call this method to check the current health
    public float GetHealth()
    {
        return health;
    }
}
