using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollide : MonoBehaviour
{

    public AudioClip collisionSound;  // Reference to the audio clip
    private AudioSource audioSource;
    private float punchForce = 10f;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            // Add the AudioSource component if not present
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // When the hand collider enters another collider
        if (other.CompareTag("Enemy"))
        {
            // Do something, like damaging the enemy
            Debug.Log("Hit enemy!");
            audioSource.PlayOneShot(collisionSound);

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
