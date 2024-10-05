using UnityEngine;

public class ScreamTrigger : MonoBehaviour
{
    public AudioSource screamAudioSource; // Assign this in the Inspector
    public CameraShake cameraShake; // Assign the CameraShake script in the Inspector
    private bool hasPlayed = false; // To ensure the scream only plays once

    public GameObject monster;

    public Vector3 offset = new Vector3(0, 30, 0);

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player") && !hasPlayed)
        {
            screamAudioSource.Play(); // Play the scream audio
            hasPlayed = true; // Mark as played
            

            monster.gameObject.SetActive(true);

            // Start the camera shake
            StartCoroutine(cameraShake.Shake(1.5f, 0.2f)); // You can adjust duration and magnitude

            gameObject.transform.position += offset; // Disable the trigger zone
        }
    }
}
