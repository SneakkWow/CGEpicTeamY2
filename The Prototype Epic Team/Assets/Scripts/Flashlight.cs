using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For UI elements

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject FlashlightLight; // The light GameObject
    [SerializeField] Slider batterySlider; // Reference to the battery slider
    [SerializeField] float batteryDrainRate = 1f; // Rate at which battery drains per second
    private bool FlashlightActive = false;

    public float currentBattery = 100f; // Current battery level
    private Image batteryImage; // Reference to the Image component of the slider's fill
    private Light flashlight; // Reference to the Light component

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip flashlightClick;

    void Start()
    {
        FlashlightLight.SetActive(false);
        batterySlider.maxValue = currentBattery; // Set slider max value
        batterySlider.value = currentBattery; // Set slider to current battery level
        batteryImage = batterySlider.fillRect.GetComponent<Image>(); // Get the Image component of the slider's fill
        flashlight = FlashlightLight.GetComponent<Light>(); // Get the Light component
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && currentBattery != 0)
        {
            FlashlightActive = !FlashlightActive; // Toggle flashlight state
            FlashlightLight.SetActive(FlashlightActive);
            audioSource.PlayOneShot(flashlightClick, 1.0f);
        }

        if (FlashlightActive)
        {
            DrainBattery(); // Drain battery while flashlight is active
        }
    }

    void DrainBattery()
    {
        if (currentBattery > 0)
        {
            currentBattery -= batteryDrainRate * Time.deltaTime; // Reduce battery over time
            batterySlider.value = currentBattery; // Update the slider value

            // Update the battery color based on current battery level
            UpdateBatteryColor();

            // Check for flicker effect if battery is low
            if (currentBattery < 4f)
            {
                StartCoroutine(FlickerLight());
            }
        }
        else
        {
            // If battery is depleted, turn off the flashlight
            FlashlightActive = false;
            FlashlightLight.SetActive(false);
        }
    }

    void UpdateBatteryColor()
    {
        // Calculate the color based on the current battery level
        float normalizedValue = currentBattery / batterySlider.maxValue; // Normalized value between 0 and 1
        batteryImage.color = Color.Lerp(Color.red, Color.green, normalizedValue); // Interpolate between red and green
    }

    private IEnumerator FlickerLight()
    {
        float flickerDuration = 0.1f; // Duration of each flicker
        float flickerInterval = 0.1f; // Interval between flickers

        while (currentBattery > 0 && currentBattery < 20f)
        {
            flashlight.enabled = !flashlight.enabled; // Toggle the light on/off
            yield return new WaitForSeconds(flickerInterval); // Wait for the flicker interval
        }

        flashlight.enabled = false; // Ensure the light is off when battery is depleted
    }
}
