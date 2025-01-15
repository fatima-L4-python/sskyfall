using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelTransition : MonoBehaviour
{
    public string nextSceneName = "leveel2"; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // When the player collides with the trigger
        {
            Debug.Log("Transitioning to Level 2: " + nextSceneName);
            SceneManager.LoadScene(nextSceneName); // Load the next scene
        }
    }
}
