using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] Transform target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(CalculateDirection());
    }

    Vector3 CalculateDirection()
    {
        return (target.transform.position - transform.position ).normalized;
    }
}
