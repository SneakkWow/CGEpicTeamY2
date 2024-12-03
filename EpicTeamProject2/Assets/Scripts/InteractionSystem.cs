/*using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public int interactionCost = 25;  // Cost to interact with the button
    private bool isPlayerNearby = false;

    [SerializeField] private GameObject interactionPrompt;  // UI prompt
    private GoldManager goldManager;  // Reference to the GoldManager

    void Start()
    {
        goldManager = FindObjectOfType<GoldManager>();  // Find the GoldManager in the scene
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            interactionPrompt.SetActive(true);  // Show the prompt
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            interactionPrompt.SetActive(false);  // Hide the prompt
        }
    }

    void Interact()
    {
        // Check if the player has enough gold before interacting
        if (goldManager.SpendGold(interactionCost))
        {
            // Interact with the system (e.g., reward the player)
            Debug.Log("Interaction successful!");
            // Add your interaction rewards here (e.g., new weapon, health, etc.)
        }
        else
        {
            Debug.Log("Not enough gold to interact.");
        }
    }
}
*/