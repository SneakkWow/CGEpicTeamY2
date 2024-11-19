using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public int currentGold = 100;  // Player's current gold
    public int interactionCost = 25;  // Initial cost
    public float newWeaponChance = 0.25f;  // 25% chance for a new weapon
    public float moreGoldChance = 0.25f;  // 25% chance for more gold
    public float moreMaxHealthChance = 0.25f;  // 25% chance for max health increase
    public float moreHealthChance = 0.25f;  // 25% chance for health restore

    public int goldReward = 50;  // Gold reward amount
    public int healthIncrease = 10;  // Max health increase
    public int healthRestore = 20;  // Health restore amount

    public int maxHealth = 100;  // Player's max health
    public int currentHealth = 100;  // Player's current health

    private bool isPlayerNearby = false;  // Tracks if the player is near

    [SerializeField] private GameObject interactionPrompt; // Reference to the UI prompt

    void Update()
    {
        // Check for interaction input only when the player is nearby
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
            interactionPrompt.SetActive(true); // Show the prompt
            Debug.Log("Player is near. Press E to interact.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            interactionPrompt.SetActive(false); // Hide the prompt
            Debug.Log("Player left the interaction zone.");
        }
    }

    void Interact()
    {
        if (currentGold >= interactionCost)
        {
            currentGold -= interactionCost;  // Deduct gold
            interactionCost += 25;  // Increase the cost for next interaction

            // Determine the reward
            float randomValue = Random.value;  // Random value between 0 and 1
            if (randomValue < newWeaponChance)
            {
                GrantNewWeapon();
            }
            else if (randomValue < newWeaponChance + moreGoldChance)
            {
                currentGold += goldReward;
                Debug.Log("You received more gold!");
            }
            else if (randomValue < newWeaponChance + moreGoldChance + moreMaxHealthChance)
            {
                maxHealth += healthIncrease;
                Debug.Log("Your max health increased!");
            }
            else
            {
                currentHealth = Mathf.Min(currentHealth + healthRestore, maxHealth);
                Debug.Log("You restored health!");
            }
        }
        else
        {
            Debug.Log("Not enough gold!");
        }
    }

    void GrantNewWeapon()
    {
        Debug.Log("You received a new weapon!");
        // Implement logic for granting a new weapon
    }
}
