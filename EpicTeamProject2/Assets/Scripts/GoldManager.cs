using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public int currentGold = 0;  // Player's gold
    public Text goldText;        // UI Text element to display the gold

    private void Start()
    {
        // Initialize UI
        UpdateGoldUI();
    }

    // Method to increase gold (called when enemy dies)
    public void AddGold(int amount)
    {
        currentGold += amount;
        UpdateGoldUI();  // Update the gold display
    }

    // Method to deduct gold (called by the InteractionSystem)
    public bool SpendGold(int amount)
    {
        if (currentGold >= amount)
        {
            currentGold -= amount;
            UpdateGoldUI();  // Update the gold display
            return true;
        }
        return false;  // Not enough gold
    }

    // Method to update the UI text with the current gold
    private void UpdateGoldUI()
    {
        if (goldText != null)
        {
            goldText.text = "Gold: " + currentGold.ToString();
        }
    }
}
