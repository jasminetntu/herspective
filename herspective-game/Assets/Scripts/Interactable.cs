using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public UnityEvent interactAction;
    [SerializeField] public TextMeshProUGUI interactText;
    public AudioClip interactSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            interactText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            interactText.gameObject.SetActive(false);
        }
    }

    public void Interact()
    {
        if (isInRange)
        {
            interactAction.Invoke();
        }
    }
}
