using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour
{
    private GameObject[] coins; // To store all the coin GameObjects

    // Finds all coins in the scene
    private void FindCoins()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin");
    }

    // Method to disable coins for a certain amount of time
    public void DisableCoinsForTime(float time)
    {
        FindCoins(); // Make sure to find all coins each time it's called

        // Disable all coins
        foreach (GameObject coin in coins)
        {
            coin.SetActive(false);
        }

        // Wait for the specified time and then enable coins again
        StartCoroutine(EnableCoinsAfterTime(time));
    }

    private IEnumerator EnableCoinsAfterTime(float time)
    {
        // Wait for the specified time
        yield return new WaitForSeconds(time);

        // Enable all coins again
        foreach (GameObject coin in coins)
        {
            coin.SetActive(true);
        }
    }
}
