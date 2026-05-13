using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 5f;

    public float gravity = -40f;

    public float jumpHeight = 4.5f;

    public Transform groundCheck;

    public float groundDistance = 0.15f;

    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    void Update()
    {
        // Check if player touching ground
        isGrounded = Physics.CheckSphere(
            groundCheck.position,
            groundDistance,
            groundMask
        );

        // Prevent extra downward force
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Movement
        float x = Input.GetAxis("Horizontal");

        float z = Input.GetAxis("Vertical");

        Vector3 move =
            transform.right * x +
            transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        // Jump only on ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y =
                Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}