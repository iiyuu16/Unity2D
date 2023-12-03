using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneSwitch : MonoBehaviour
{
    public float countdownDuration = 3.0f;
    public TextMeshProUGUI countdownText;
    private bool isCountdownActive = false;

    public void NextScene()
    {
        Debug.Log("Play");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ResetStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Level1 to MainMenu
    public void LVL1toMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //Level2 to MainMenu
    public void LVL2toMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCountdownActive)
        {
            Debug.Log("Player entered trigger, starting countdown...");
            StartCoroutine(Countdown());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger, resetting countdown...");
            StopAllCoroutines();
            ResetCountdown();
        }
    }
    IEnumerator Countdown()
    {
        isCountdownActive = true;

        float countdownTimer = countdownDuration;

        while (countdownTimer > 0)
        {
            countdownText.text = Mathf.CeilToInt(countdownTimer).ToString();
            yield return new WaitForSeconds(1.0f);
            countdownTimer--;
        }

        countdownText.text = "0";
        NextScene();
    }

    void ResetCountdown()
    {
        isCountdownActive = false;
        countdownText.text = "";
    }
}
