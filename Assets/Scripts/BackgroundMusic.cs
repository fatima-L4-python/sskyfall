using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public float volume = 0.5f; // to set the volume (0.0 to 1.0)

    private AudioSource audioSource; 
    private static bool musicExists = false; 

    void Awake()
    {
        // Ensure this GameObject persists across scenes
        if (musicExists)
        {
            Destroy(gameObject); // If music already exists, destroy this one
        }
        else
        {
            DontDestroyOnLoad(gameObject); // Keep this object across scene transitions
            musicExists = true; 
        }

        // Add AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set up the AudioSource
        audioSource.clip = backgroundMusic;
        audioSource.volume = volume;
        audioSource.loop = true; // Loop the music
        audioSource.playOnAwake = true; // Play when the game starts

        // Start playing the background music if it's not already playing
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
