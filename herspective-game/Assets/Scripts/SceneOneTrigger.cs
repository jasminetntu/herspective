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

    void CamFollow()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        mainCamera.transform.position = new Vector3(playerPos.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
    }

    public void toggleCameraFollow()
    {
        camFollow = !camFollow;
    }

    public void AddSpeed()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        pm.moveSpeed += 1f;
    }

    public void Run()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        pm.moveSpeed += 3f;
    }
}
