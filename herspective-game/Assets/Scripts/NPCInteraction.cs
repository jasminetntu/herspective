using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public PlayerMovement playerMovement;

    bool playerInRange = false;
    bool hasTalked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTalked)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        if (playerInRange && !hasTalked && Input.GetKeyDown(KeyCode.E))
        {
            hasTalked = true;

            // STOP PLAYER MOVEMENT
            playerMovement.isActive = false;

            // START DIALOGUE
            dialogueManager.StartDialogue();
        }
    }

    public void EndConversation()
    {
        // UNFREEZE MOVEMENT
        playerMovement.isActive = true;
    }
}
