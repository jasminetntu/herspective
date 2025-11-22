using Unity.Cinemachine;
using UnityEngine;

public class CameraSwitchTrigger : MonoBehaviour
{
    [Header("Cinemachine Cameras")]
    [SerializeField] private CinemachineCamera titleScreenCam; 
    [SerializeField] private CinemachineCamera creditsEndCam; 

    private bool isCredits = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player and we haven't switched yet
        if (other.CompareTag("Player") && !isCredits)
        {
            isCredits = true;
            Debug.Log("Switching to static Credits Camera.");

            // 1. Deactivate the Title Screen Camera (lower priority)
            titleScreenCam.Priority = 5; 

            // 2. Activate the Credits End Camera (higher priority)
            creditsEndCam.Priority = 20; 

        }
        else
        {
            isCredits = false;
            titleScreenCam.Priority = 20; 
            creditsEndCam.Priority = 5; 
        }
    }
}