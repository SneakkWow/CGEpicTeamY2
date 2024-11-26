using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollide : MonoBehaviour
{

    private float punchForce = 10f;

    private void OnTriggerEnter(Collider other)
    {
        // When the hand collider enters another collider
        if (other.CompareTag("Enemy"))
        {
            // Do something, like damaging the enemy
            Debug.Log("Hit enemy!");

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
