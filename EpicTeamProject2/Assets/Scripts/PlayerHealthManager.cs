using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHealth = 100;  // Maximum health
    private int currentHealth;
    public float flashDuration = 0.2f;  // Duration of red flash
    public AudioClip hurtSound;
    private AudioSource audioSource;
    private float flashTimer = 0f;

    // UI Elements
    //public Text healthText;  // Text to display health
    public Image flashImage;  // Image for red flash effect
    public GameObject deadText;
    public GameObject restartText;

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;
        flashImage.gameObject.SetActive(false);  // Hide flash at start
        Time.timeScale = 1f;
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        // Update the flash timer
        if (flashTimer > 0)
        {
            flashTimer -= Time.deltaTime;

            // Flashing effect
            if (flashTimer > 0)
            {
                flashImage.gameObject.SetActive(true);  // Show red flash
            }
            else
            {
                flashImage.gameObject.SetActive(false);  // Hide red flash
            }
        }

        if (currentHealth <= 0)
        {
            Time.timeScale = 0;
            deadText.SetActive(true);
            restartText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R)) {
                RestartScene();
            }
        }
    }

    // Call this method when the player collides with an enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);  // Reduce health by 10 (or any other value)
        }
    }

    // Method to take damage
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        audioSource.PlayOneShot(hurtSound);
        if (currentHealth < 0) currentHealth = 0;  // Ensure health doesn't go below 0

        // Flash screen red
        flashTimer = flashDuration;

    }

    void RestartScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
