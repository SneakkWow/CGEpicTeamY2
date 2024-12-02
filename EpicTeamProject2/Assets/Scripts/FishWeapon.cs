using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishWeapon : MonoBehaviour
{
    public AudioClip collisionSound;  // Reference to the audio clip
    public AudioClip flopSound;
    private AudioSource audioSource;
    private float punchForce = 10f;
    private Collider attackCollider;  // Reference to the sphere collider used for the attack
    private float attackDuration = 0.5f;

    private EnemyHealth enemyHealth;

    //private enemyCollide EC;

    //private EnemyRagdollControl ERC;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        //EC = GetComponent<enemyCollide>();

        if (audioSource == null)
        {
            // Add the AudioSource component if not present
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Get the Collider component attached to this GameObject
        attackCollider = GetComponent<BoxCollider>();
        attackCollider.enabled = false;
        if (attackCollider == null)
        {
            Debug.LogWarning("No collider found on the attack GameObject!");
        }
    }

    // This function will enable the attack collider when the attack starts
    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 is for left mouse button
        {
            StartCoroutine(AttackCoroutine());  // Start the attack using the coroutine
        }

    }

    // Coroutine that handles the attack timing (enabling and disabling the collider)
    private IEnumerator AttackCoroutine()
    {
        // Enable the attack collider when the attack starts
        attackCollider.enabled = true;

        // Wait for the specified duration (e.g., the length of the attack animation or time)
        yield return new WaitForSeconds(attackDuration);

        // Disable the attack collider after the attack duration
        if (attackCollider != null)
        {
            attackCollider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // When the hand collider enters another collider
        if (other.CompareTag("Enemy"))
        {
            EnemyRagdollControl ERC = other.GetComponent<EnemyRagdollControl>();

            enemyHealth = other.GetComponent<EnemyHealth>();

            // Do something, like damaging the enemy
            Debug.Log("Hit enemy!");

            if (enemyHealth.GetHealth() > 0)
            {
                audioSource.PlayOneShot(flopSound); // hit sound effect
            }


            enemyHealth.TakeDamage(65); // change damage here

            if (enemyHealth.GetHealth() <= 0)
            {
                // Enable ragdoll
                ERC.SetRagdollState(true);
                audioSource.PlayOneShot(collisionSound); // kill sound effect
            }

            // Apply a force to the enemy's Rigidbody
            Rigidbody enemyRigidbody = other.GetComponent<Rigidbody>();
            if (enemyRigidbody != null)
            {
                // Calculate the direction of the punch (you can adjust this based on the punch animation)
                Vector3 direction = (other.transform.position - transform.position).normalized;

                // Apply the punch force to the enemy
                enemyRigidbody.AddForce(direction * punchForce, ForceMode.Impulse);
            }
        }
    }
}
