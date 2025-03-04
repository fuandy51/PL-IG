using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject winText;
    public GameObject loseText;
    public GameObject pauseText;
    public bool isGamePaused = false;

    void Start()
    {
        winText.SetActive(false);
        loseText.SetActive(false);
        pauseText.SetActive(false);
    }

    void Update()
    {
        // Menangani input untuk pause dan unpause game
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseGame();
        }
    }

    public void WinGame()
    {
        winText.SetActive(true);
        Time.timeScale = 0f; // Menghentikan waktu (pause)
    }

    public void LoseGame()
    {
        loseText.SetActive(true);
        Time.timeScale = 0f; // Menghentikan waktu (pause)
    }

    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            pauseText.SetActive(true);
            Time.timeScale = 0f; // Menghentikan waktu (pause)
        }
        else
        {
            pauseText.SetActive(false);
            Time.timeScale = 1f; // Melanjutkan waktu
        }
    }
}
