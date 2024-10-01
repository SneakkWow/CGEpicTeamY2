using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    public float slideSpeed = 2f; // Speed at which the door slides up
    public float slideDistance = 5f; // Distance the door will slide up
    private Vector3 initialPosition;
    private bool isSliding = false;

    private void Start()
    {
        // Store the initial position of the door
        initialPosition = transform.position;
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
    }
}
