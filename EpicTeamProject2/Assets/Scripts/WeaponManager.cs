using UnityEngine;
using UnityEngine.UI;  // To use UI elements

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weapons;  // Array of weapons the player can equip
    private int currentWeaponIndex = 0;  // Index of the current weapon
    private Text weaponToggleText;  // Reference to the UI text for showing the weapon name

    private int weaponIndex = 0;

    // Assuming you have a method for initializing the UI text reference
    void Start()
    {
        // Find the Weapon Toggle Text UI element in the scene
        weaponToggleText = GameObject.Find("WeaponToggleText").GetComponent<Text>();

        // Ensure the UI text is hidden at the start
        //weaponToggleText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Check if the player presses 1 or 2 to switch weapons
        if (Input.GetKeyDown(KeyCode.Alpha1) && weaponIndex > 0)
        {
            weaponIndex--;
            ShowWeaponText(weaponIndex);
            // EquipWeapon(weaponIndex);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) &&  weaponIndex < weapons.Length)
        {
            weaponIndex++;
            ShowWeaponText(weaponIndex);
            // EquipWeapon(weaponIndex);
        }

        // Optionally: Hide the weapon toggle text after a short time
        /*if (weaponToggleText.gameObject.activeSelf)
        {
            Invoke("HideWeaponText", 1f);  // Hide after 1 second
        }*/

        if (Input.GetKeyDown(KeyCode.F))
        {
           EquipWeapon(weaponIndex);
        }
    }

    void EquipWeapon(int index)
    {
        // Deactivate the current weapon
        weapons[currentWeaponIndex].SetActive(false);

        // Set the new weapon as the current weapon
        currentWeaponIndex = index;
        weapons[currentWeaponIndex].SetActive(true);
    }

    void ShowWeaponText(int weaponIndex)
    {
        // Set the text to show the name of the weapon
        weaponToggleText.text = "Weapon Index: " + weapons[weaponIndex].name;

        // Make the text visible
        //weaponToggleText.gameObject.SetActive(true);
    }

    void HideWeaponText()
    {
        // Hide the text after a short delay
        weaponToggleText.gameObject.SetActive(false);
    }
}
