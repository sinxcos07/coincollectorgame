using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    public AudioSource footstepSource;

    public float stepDelay = 0.5f;

    private float stepTimer;

    void Update()
    {
        float moveX =
            Input.GetAxisRaw("Horizontal");

        float moveZ =
            Input.GetAxisRaw("Vertical");

        bool isMoving =
            moveX != 0 || moveZ != 0;

        if (isMoving)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                // Random slight pitch
                footstepSource.pitch =
                    Random.Range(0.9f, 1.1f);

                footstepSource.PlayOneShot(
                    footstepSource.clip
                );

                stepTimer = stepDelay;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }
}