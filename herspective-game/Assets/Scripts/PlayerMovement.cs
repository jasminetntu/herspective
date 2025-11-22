using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private SpriteRenderer sr;
    private Vector2 movement;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponentInChildren<SpriteRenderer>(); // sprite on child object
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // Read input every frame
        float moveX = Input.GetAxisRaw("Horizontal");  // A/D or Left/Right

        // Set movement vector (X only for now)
        movement = new Vector2(moveX, 0f).normalized;

        //ANIMATIONS
        if (moveX != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        // Flip sprite based on direction
        if (moveX > 0.01f)
        {
            sr.flipX = false; // facing right
        }
        else if (moveX < -0.01f)
        {
            sr.flipX = true;  // facing left
        }
    }

    void FixedUpdate()
    {
        // Current 3D position
        Vector3 pos3D = rb.position;

        // Convert 2D movement (x,y) to 3D (x,y,0)
        Vector3 move3D = new Vector3(movement.x, movement.y, 0f);

        // Apply movement on the physics step
        rb.MovePosition(pos3D + move3D * moveSpeed * Time.fixedDeltaTime);
    }

    // Optional helper if you ever want to manually toggle
    void FlipHorizontally()
    {
        sr.flipX = !sr.flipX;
    }
}
