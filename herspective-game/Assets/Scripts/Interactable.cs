using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public UnityEvent interactAction;
    [SerializeField] public TextMeshProUGUI interactText;
    public AudioClip interactSound;
    public bool isPassive = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isPassive)
            {
                Interact();
            }
            else
            {
                //isInRange = true;
                //interactText.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (!isPassive)
        {
            //isInRange = false;
            //interactText.gameObject.SetActive(false);
        }
    }

    public void Interact()
    {
        interactAction.Invoke();
    }
}
