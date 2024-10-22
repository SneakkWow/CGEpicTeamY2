using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For UI elements

public class Pickup : MonoBehaviour
{
    public float lookDistance = 20f; // Distance to look for item
    public GameObject player; // Reference to the player GameObject
    public Text interactionText; // Reference to the UI Text for interaction feedback
    private bool isPlayerLookingAtItem = false; // Track if the player is looking at the item
    public Flashlight currentFlashlight;

    void Start()
    {
        interactionText.gameObject.SetActive(false); // Hide the interaction text initially
    }

    void Update()
    {
        IsPlayerLookingAtItem();

        // Handle interaction if the player is looking at the item
        if (isPlayerLookingAtItem && Input.GetKeyDown(KeyCode.E))
        {
            InteractWithItem();
        }
    }

    private void IsPlayerLookingAtItem()
    {
        Vector3 directionToItem = transform.position - player.transform.position;
        float angle = Vector3.Angle(player.transform.forward, directionToItem);

        // Check if the item is within the player's field of view
        if (angle < 25f && directionToItem.magnitude <= lookDistance)
        {
            RaycastHit hit;
            // Cast a ray from the player's position to the item
            if (Physics.Raycast(player.transform.position, directionToItem.normalized, out hit, lookDistance))
            {
                // Check if the ray hits the item
                if (hit.collider.gameObject == gameObject)
                {
                    isPlayerLookingAtItem = true; // Player is looking at the item
                    interactionText.gameObject.SetActive(true); // Show the interaction prompt
                    return;
                }
            }
        }
        else
        {
            isPlayerLookingAtItem = false; // Player is not looking at the item
            interactionText.gameObject.SetActive(false); // Hide the interaction prompt
        }
        
    }

    private void InteractWithItem()
    {
        // Logic to collect the item (e.g., a battery)
        //Debug.Log("Item collected!"); // Placeholder for item collection logic

        // Destroy or deactivate the item
        Destroy(gameObject);
        interactionText.gameObject.SetActive(false); // Hide the prompt after interaction

        currentFlashlight.currentBattery = 100f;
        //currentFlashlight.batterySlider.value = currentFlashlight.currentBattery;
        //currentFlashlight.FlashlightLight.SetActive(true);
        currentFlashlight.flashlight.enabled = true;
    }
}
