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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isPassive)
            {
                //isInRange = true;
                //interactText.gameObject.SetActive(true);
            }
            else
            {
                Interact();
                Debug.Log(collision.gameObject + " has collidede with " + this.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isPassive)
        {
            //isInRange = false;
            //interactText.gameObject.SetActive(false);
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
