using UnityEngine;

public class SceneOneTrigger : MonoBehaviour
{
    public Camera mainCamera;
    public bool camFollow = false;

    private void Update()
    {
        if (camFollow)
        {
            CamFollow();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            camFollow = true;
        }
    }

    void CamFollow()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        mainCamera.transform.position = new Vector3(playerPos.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
    }
}
