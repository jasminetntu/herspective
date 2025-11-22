using UnityEngine;
using TMPro;
using System.Collections;

/*  Layer the text depending on what order you want it to go in 
 *  put it all in the same canvas, and then the top one would go first
 *  then the second. It goes to the next one when you click the right arrow
 *  * 
 * 
 * 
 */

public class TextPopupManager : MonoBehaviour
{

    [SerializeField] float popUpDelay = .5f;

    [Header("UI Text to show pop-ups")]
    public TMP_Text popupText;

    [Header("List of pop-up messages for this room")]
    [TextArea(2, 6)]
    public GameObject[] messages;

    public int index = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowMessages();
        }
    }

    public void ShowMessages()
    {
        StartCoroutine(PopUps());
    }

    IEnumerator PopUps()
    {
        for (int i = 0; i < messages.Length; i++)
        {
            messages[i].SetActive(true);
            yield return new WaitForSeconds(popUpDelay);
        }
    }
}
