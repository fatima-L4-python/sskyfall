using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // For restarting the scene
using System.Collections; 

public class GameManager : MonoBehaviour
{
    public int totalHealth = 4; // Total health of the player
    public GameObject[] healthBars; // Array of health bar GameObjects
    public GameObject gameOverPanel; // Reference to the Game Over panel
    public GameObject shieldUI; // Reference to the shield 
    public bool isShieldActive = false; // To check if shield is active
    public float shieldDuration = 5f; // Duration of the shield in seconds
    public AudioClip shieldActiveSound; // Sound effect to play when the shield is active
    private AudioSource audioSource; // AudioSource to play sounds

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Ensure the Game Over panel is hidden when the game starts
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // Update health bar UI initially
        UpdateHealthBars();

        // Initially hide the shield 
        if (shieldUI != null)
        {
            shieldUI.SetActive(false);
        }
    }

    void Update()
    {
        // If shield is active show the shield
        if (isShieldActive && shieldUI != null)
        {
            shieldUI.SetActive(true);
        }
        else if (shieldUI != null)
        {
            shieldUI.SetActive(false);
        }
    }

    // Decrease health by the specified amount
    public void DecreaseHealth(int amount)
    {
        // If the shield is active don't decrease health
        if (isShieldActive)
        {
            Debug.Log("Shield active! No damage taken.");
            return; // Ignore health decrease
        }

        totalHealth -= amount;

        // Update health bars
        UpdateHealthBars();

        // Check if health is zero and trigger Game Over
        if (totalHealth <= 0)
        {
            GameOver();
        }
    }

    // Update health bar UI based on total health
    private void UpdateHealthBars()
    {
        for (int i = 0; i < healthBars.Length; i++)
        {
            healthBars[i].SetActive(i < totalHealth); // Show only active health bars
        }
    }

    // Method to activate the shield and start the timer
    public void ActivateShield()
    {
        isShieldActive = true;

        // Play the shield active sound
        if (audioSource != null && shieldActiveSound != null)
        {
            audioSource.clip = shieldActiveSound;
            audioSource.loop = true; // Loop the sound for the shield duration
            audioSource.Play();
        }

        // Start shield duration countdown
        StartCoroutine(ShieldDuration());
    }

    // Shield duration countdown
    private IEnumerator ShieldDuration()
    {
        yield return new WaitForSeconds(shieldDuration); // Wait for the shield duration
        isShieldActive = false; // Deactivate the shield

        // Stop the shield active sound
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    // Handle Game Over logic
    private void GameOver()
    {
        Debug.Log("Game Over!");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // Show the Game Over panel
        }
        Time.timeScale = 0; // Pause the game
    }

    // Method to restart the game
    public void TryAgain()
    {
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
