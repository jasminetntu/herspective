using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Rigidbody rb;
    [SerializeField] SpriteRenderer sr;

    public bool isFollowing = false;
    public float maxDistance = 4f;
    public float moveSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtTarget();
        
    }

    private void LateUpdate()
    {
        if (isFollowing)
        {
            Follow();
        }
    }

    Vector3 CalculateDirection()
    {
        return (target.transform.position - transform.position ).normalized;
    }

    void LookAtTarget()
    {
        //transform.rotation = Quaternion.LookRotation(CalculateDirection());
        if (CalculateDirection().x > 0 && sr.flipX)
        {
            FlipHorizontally();
        }
        else if (CalculateDirection().x < 0 && !sr.flipX)
        {
            FlipHorizontally();
        }
    }

    void Follow()
    {
        if ((target.transform.position - transform.position).magnitude > maxDistance)
        {
            Vector2 dir = new Vector2(CalculateDirection().x, 0);
            Vector2 pos2D = new Vector2(rb.position.x, rb.position.y);
            rb.AddForce(dir * moveSpeed);
        }
    }

    public void startFollowing()
    {
        isFollowing = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player enter");
            startFollowing();
        }
    }

    void FlipHorizontally()
    {
        sr.flipX = !sr.flipX;
    }
}
