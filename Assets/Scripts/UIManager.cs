using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject winCanvas;
    public GameObject loseCanvas;

    public Button resumeButton;
    public Button restartButton;
    public Button quitButton;
    public Button winRestartButton;
    public Button winQuitButton;
    public Button loseRestartButton;
    public Button loseQuitButton;

    private bool isPaused = false;

    void Start()
    {
        pauseCanvas.SetActive(false);
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);

        if (resumeButton != null)
            resumeButton.onClick.AddListener(TogglePause);

        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);

        if (quitButton != null)
            quitButton.onClick.AddListener(QuitGame);

        if (winRestartButton != null)
            winRestartButton.onClick.AddListener(RestartGame);

        if (winQuitButton != null)
            winQuitButton.onClick.AddListener(QuitGame);

        if (loseRestartButton != null)
            loseRestartButton.onClick.AddListener(RestartGame);

        if (loseQuitButton != null)
            loseQuitButton.onClick.AddListener(QuitGame);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseCanvas.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }

    public void ShowWinScreen()
    {
        winCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void ShowLoseScreen()
    {
        loseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
