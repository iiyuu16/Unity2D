using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionOnDestroy : MonoBehaviour
{
    public string nextSceneName; // Specify the name of the next scene in the Unity Editor

    private void OnDestroy()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Next scene name not specified. Please set it in the Unity Editor.");
        }
    }
}
