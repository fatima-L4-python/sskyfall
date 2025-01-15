using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    public float disableTime = 3f; // Time in seconds for coins to disappear

    // When the player hits the balloon
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Makes sure that it works when the playr hits the balloon
        if (other.CompareTag("Player"))
        {
            // Find the CoinManager instance and disable the coins for a certain amount of time
            CoinManager coinManager = FindObjectOfType<CoinManager>();
            if (coinManager != null)
            {
                coinManager.DisableCoinsForTime(disableTime);
            }

            // Destroy the balloon after collision
            Destroy(gameObject);
        }
    }
}
