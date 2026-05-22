using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [Header("Settings")]
    public float bobSpeed = 14f;

    public float bobAmount = 0.05f;

    private float defaultYPos;

    private float timer = 0;

    void Start()
    {
        defaultYPos =
            transform.localPosition.y;
    }

    void Update()
    {
        // Detect movement input
        float moveX =
            Input.GetAxisRaw("Horizontal");

        float moveZ =
            Input.GetAxisRaw("Vertical");

        bool isMoving =
            moveX != 0 || moveZ != 0;

        if (isMoving)
        {
            timer +=
                Time.deltaTime * bobSpeed;

            transform.localPosition =
                new Vector3(
                    transform.localPosition.x,

                    defaultYPos +
                    Mathf.Sin(timer) *
                    bobAmount,

                    transform.localPosition.z
                );
        }
        else
        {
            timer = 0;

            transform.localPosition =
                new Vector3(
                    transform.localPosition.x,

                    Mathf.Lerp(
                        transform.localPosition.y,
                        defaultYPos,
                        Time.deltaTime * 5f
                    ),

                    transform.localPosition.z
                );
        }
    }
}