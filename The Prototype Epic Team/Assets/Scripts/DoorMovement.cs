using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    public float slideSpeed = 2f; // Speed at which the door slides up
    public float slideDistance = 5f; // Distance the door will slide up
    private Vector3 initialPosition;
    private bool isSliding = false;

    public AudioSource audioSource;  // Reference to the AudioSource component

    private void Start()
    {
        // Store the initial position of the door
        initialPosition = transform.position;

        // Optionally, ensure we have an AudioSource component on this GameObject
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        // If the door is sliding, move it upwards
        if (isSliding)
        {
            // Move the door up by a certain speed
            transform.position = Vector3.MoveTowards(transform.position, initialPosition + Vector3.up * slideDistance, slideSpeed * Time.deltaTime);

            // Stop the door movement once it reaches the desired position
            if (transform.position == initialPosition + Vector3.up * slideDistance)
            {
                isSliding = false; // Stop sliding when the door reaches the top
            }
        }
    }

    // Method to start the sliding action
    public void StartSliding()
    {
        isSliding = true;

        // Play the sound when the door starts sliding
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
