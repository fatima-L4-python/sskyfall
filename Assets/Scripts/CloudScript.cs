using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public AudioClip cloudHitSound; // Sound effect for hitting the cloud
    private AudioSource audioSource; 

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayCloudHitSound(); // Play the cloud hit sound

            // Reference the GameManager to decrease health
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                Debug.Log("Cloud hit! Decreasing health.");
                gameManager.DecreaseHealth(1); // Decrease health by 1
            }
        }
    }


    private void PlayCloudHitSound()
    {
        if (cloudHitSound != null)
        {
            audioSource.PlayOneShot(cloudHitSound); // Play the sound
        }
    }
}
