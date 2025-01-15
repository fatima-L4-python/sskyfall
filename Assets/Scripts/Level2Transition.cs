using UnityEngine;
using System.Collections; 
using UnityEngine.UI; 

public class Level2Transition : MonoBehaviour
{
    public GameObject winnerText; 
    public PlayerMovement playerMovement; 
    public AudioClip grassTouchSound; // Sound to play when the player touches the grass

    private AudioSource audioSource;

    void Start()
    {
        // Add or get the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            // Stop the player's movement
            if (playerMovement != null)
            {
                playerMovement.StopPlayerMovement();
            }

            // Play the grass touch sound
            if (audioSource != null && grassTouchSound != null)
            {
                audioSource.PlayOneShot(grassTouchSound);
            }

            // Display the "Winner" text
            if (winnerText != null)
            {
                winnerText.SetActive(true);
            }

            StartCoroutine(WaitBeforePausing());
        }
    }

    private IEnumerator WaitBeforePausing()
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        Time.timeScale = 0; // Pause the game
        Debug.Log("Player wins! Game paused.");
    }
}
