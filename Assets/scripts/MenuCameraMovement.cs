using UnityEngine;

public class MenuCameraMovement : MonoBehaviour
{
    public float rotationAmount = 20f;

    public float rotationSpeed = 0.4f;

    private Quaternion startRotation;

    void Start()
    {
        startRotation = transform.rotation;
    }

    void Update()
    {
        float angle =
            Mathf.Sin(Time.time * rotationSpeed)
            * rotationAmount;

        transform.rotation =
            startRotation *
            Quaternion.Euler(0, angle, 0);
    }
}