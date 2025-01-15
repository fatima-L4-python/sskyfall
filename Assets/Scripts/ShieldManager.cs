using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public GameManager gameManager; 
    public AudioClip shieldPickupSound; // Sound when shield is picked up

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Checks if the player collides with the shield object
        if (other.CompareTag("Player"))
        {
            // Activate shield in the GameManager
            if (gameManager != null)
            {
                gameManager.ActivateShield(); // Activate the shield for the player
            }

            // Play shield pickup sound if available
            if (audioSource != null && shieldPickupSound != null)
            {
                audioSource.PlayOneShot(shieldPickupSound);
            }

            // Destroy the shield object after it has been collected
            Destroy(gameObject);
        }
    }
}
