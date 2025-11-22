using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("How many actions must be completed in THIS scene?")]
    public int totalActions = 3;         // Set this per scene in the Inspector
    public int completedActions = 0;

    [Header("Name of the next scene to load")]
    public string nextSceneName;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CompleteTask();
        }
    }

    // Call this from your UI button
    public void CompleteTask()
    {
        completedActions++;

        Debug.Log("Action " + completedActions + " completed.");

        // If all actions are completed change scene
        if (completedActions >= totalActions)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
