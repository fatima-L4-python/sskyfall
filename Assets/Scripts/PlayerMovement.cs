using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Walking speed
    private Rigidbody2D rb;
    private bool isMoving = true; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isMoving)
        {
            float horizontal = Input.GetAxis("Horizontal");

            // Set the player's velocity on the X-axis to move based on user input
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        else
        {
            // Stop the player's movement by setting velocity to 0
            rb.velocity = Vector2.zero;
        }
    }

    //To stop the player when they reach the grass
    public void StopPlayerMovement()
    {
        isMoving = false; // Disable movement
    }
}
