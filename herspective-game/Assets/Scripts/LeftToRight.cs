using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LeftToRight : MonoBehaviour
{
    public bool isRunning = false;
    public float moveSpeed = 3f;

    private Rigidbody rb;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        if (!isRunning) return;

        // Move along +X at moveSpeed units per second
        Vector3 newPosition = rb.position + Vector3.right * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }

    public void StartRunning()
    {
        isRunning = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isRunning = false;
            sr.flipX = true;
        }
    }
}
