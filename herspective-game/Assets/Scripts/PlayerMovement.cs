using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Read input every frame
        float moveX = Input.GetAxisRaw("Horizontal");  // A/D or Left/Right

        movement = new Vector2(moveX, 0).normalized;
    }

    void FixedUpdate()
    {
        // Apply movement on the physics step
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
