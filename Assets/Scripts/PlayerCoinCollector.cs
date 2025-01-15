using UnityEngine;
using TMPro;

public class PlayerCoinCollector : MonoBehaviour
{
    public int coinsCollected = 0; // Tracks the number of coins collected
    public TextMeshProUGUI coinText; 
    public AudioClip coinSound; // Coin collection sound effect

    private AudioSource audioSource; 

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coinsCollected++; // Increment the coin count
            Destroy(other.gameObject); // Removes the coin from the scene
            PlayCoinSound(); // Play the sound effect
            UpdateCoinUI(); 
        }
    }

    private void PlayCoinSound()
    {
        if (audioSource != null && coinSound != null)
        {
            audioSource.PlayOneShot(coinSound); // Play the coin sound
        }
    }

    private void UpdateCoinUI()
    {
        // Update the text displayed on the screen
        coinText.text = "Coins: " + coinsCollected;
    }
}
