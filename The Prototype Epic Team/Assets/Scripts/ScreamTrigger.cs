using UnityEngine;

public class ScreamTrigger : MonoBehaviour
{
    public AudioSource screamAudioSource; // Assign this in the Inspector
    public CameraShake cameraShake; // Assign the CameraShake script in the Inspector
    private bool hasPlayed = false; // To ensure the scream only plays once

    public GameObject monster;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player") && !hasPlayed)
        {
            screamAudioSource.Play(); // Play the scream audio
            hasPlayed = true; // Mark as played
            

            monster.gameObject.SetActive(true);

            // Start the camera shake
            StartCoroutine(cameraShake.Shake(1f, 0.1f)); // You can adjust duration and magnitude

            gameObject.SetActive(false); // Disable the trigger zone
        }
    }
}
