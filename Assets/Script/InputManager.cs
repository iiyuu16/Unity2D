using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        // Pause or resume the game based on the 'isPaused' flag
        Time.timeScale = isPaused ? 0 : 1;

        // Show or hide the pause menu based on the 'isPaused' flag
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(isPaused);
        }
    }
}
