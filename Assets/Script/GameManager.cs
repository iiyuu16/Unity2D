using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public TopDownCharacterController player;

    void Start()
    {
        // Make sure the game over screen is initially disabled
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    void Update()
    {
        // Check for game over conditions
        if (IsGameOver())
        {
            // Trigger game over with a delay
            Invoke("ShowGameOverScreen", 1.25f);
        }
    }

    bool IsGameOver()
    {
        // You can add more conditions here based on your game logic
        return player.currentHP <= 0;
    }

    void ShowGameOverScreen()
    {
        // Pause the game or do any other necessary actions
        Time.timeScale = 0;

        // Enable the game over screen
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void RestartGame()
    {
        // Reload the current scene to restart the game
        Time.timeScale = 1; // Ensure time scale is reset
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
