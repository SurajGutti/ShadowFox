using UnityEngine;
using UnityEngine.SceneManagement;

public class Scripts_GameMenu : MonoBehaviour
{
    [SerializeField] private Scripts_GameManager gameManager;

    public GameObject pauseUI;
    public GameObject gameUI;

    public void Resume()
    {
        pauseUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
        gameManager.isPaused = false;
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0f;
        gameManager.isPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        gameManager.RestartLevel();
    }

    public void NextLevel()
    {
        gameManager.NextLevel();
    }
}
