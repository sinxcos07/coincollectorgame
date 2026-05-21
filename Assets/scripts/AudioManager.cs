using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource bgMusic;

    void Awake()
    {
        // Keep only one AudioManager
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);

            // Auto assign AudioSource
            if (bgMusic == null)
            {
                bgMusic =
                    GetComponent<AudioSource>();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float volume)
    {
        // Global game volume
        AudioListener.volume =
            Mathf.Clamp01(volume);
    }
}