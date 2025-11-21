using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Read input every frame
        float moveX = Input.GetAxisRaw("Horizontal");  // A/D or Left/Right

        movement = new Vector2(moveX, 0).normalized;
    }

    void FixedUpdate()
    {
        Vector2 pos2D = new Vector2(rb.position.x, rb.position.y);
        // Apply movement on the physics step
        rb.MovePosition(pos2D + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
