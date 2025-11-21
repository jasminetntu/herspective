using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Rigidbody rb;

    public bool isFollowing = false;
    public float maxDistance = 4f;
    public float moveSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtTarget();
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
        transform.rotation = Quaternion.LookRotation(CalculateDirection());
    }

    void Follow()
    {
        if ((target.transform.position - transform.position).magnitude > maxDistance)
        {
            Vector2 dir = new Vector2(CalculateDirection().x, 0);
            Vector2 pos2D = new Vector2(rb.position.x, rb.position.y);
            rb.MovePosition(pos2D + dir * moveSpeed * Time.fixedDeltaTime); 
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
}
