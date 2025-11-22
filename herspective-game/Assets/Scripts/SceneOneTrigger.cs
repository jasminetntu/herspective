using UnityEngine;

public class SceneOneTrigger : MonoBehaviour
{
    public GameObject[] backgrounds;
    public bool moveBackground = false;

    void Start()
    {
        // empty
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        if (moveBackground && moveX > 0)
        {
            MoveBackgrounds(moveX);
        }
    }

    void MoveBackgrounds(float moveX)
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].transform.position += new Vector3(-moveX * Time.deltaTime, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)  // <- 3D collider; often wrong in 2D projects
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().isActive = false;
            moveBackground = true;
        }
    }
}
