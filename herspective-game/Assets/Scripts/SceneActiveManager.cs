using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneActiveManager : MonoBehaviour
{
    // Call this from your UI button
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }
}
