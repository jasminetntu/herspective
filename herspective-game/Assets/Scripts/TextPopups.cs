using UnityEngine;
using TMPro;


/*  Layer the text depending on what order you want it to go in 
 *  put it all in the same canvas, and then the top one would go first
 *  then the second. It goes to the next one when you click the right arrow
 *  * 
 * 
 * 
 */





public class TextPopupManager : MonoBehaviour
{
    [Header("UI Text to show pop-ups")]
    public TMP_Text popupText;

    [Header("List of pop-up messages for this room")]
    [TextArea(2, 6)]
    public string[] messages;

    public int index = 0;

    void Start()
    {
        if (popupText == null)
        {
            Debug.LogError("PopupText not assigned!");
        }

        if (messages.Length > 0)
        {
            popupText.text = messages[0];
            popupText.gameObject.SetActive(true);
            index = 1; 
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ShowNextMessage();
        }
    }

    void ShowNextMessage()
    {
        if (index < messages.Length)
        {
            popupText.text = messages[index];
            index++;
        }
        else
        {
            popupText.gameObject.SetActive(false);
        }
    }
}
