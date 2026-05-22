using UnityEngine;

public class CreditsCamera : MonoBehaviour
{
    public Transform pointA;

    public Transform pointB;

    public float speed = 0.5f;

    private float t = 0;

    void Update()
    {
        t += Time.deltaTime * speed;

        transform.position =
            Vector3.Lerp(
                pointA.position,
                pointB.position,
                Mathf.PingPong(t, 1)
            );

        transform.rotation =
            Quaternion.Lerp(
                pointA.rotation,
                pointB.rotation,
                Mathf.PingPong(t, 1)
            );
    }
}