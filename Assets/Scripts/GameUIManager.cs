using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject pausePanel;
    public AudioSource bgm;
    public AudioSource buttonClickSound; // AudioSource untuk suara tombol
    private bool isPaused = false;

    void Start()
    {
        // Pastikan semua panel tidak aktif saat game dimulai
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    void Update()
    {
        // Cek input Escape untuk pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void ShowWinPanel()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f; // Pause game saat menang
            if (bgm != null) bgm.Stop(); // Hentikan BGM saat menang
        }
    }

    public void ShowLosePanel()
    {
        if (losePanel != null)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0f; // Pause game saat kalah
            if (bgm != null) bgm.Stop(); // Hentikan BGM saat kalah
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;

        if (bgm != null)
        {
            if (isPaused)
                bgm.Pause(); // Pause BGM saat game di-pause
            else
                bgm.Play(); // Lanjutkan BGM saat game di-unpause
        }
    }

    public void RestartGame()
    {
        PlayButtonClickSound();
        Time.timeScale = 1f;
        if (bgm != null) bgm.Play();
        Invoke("LoadCurrentScene", 0.5f); // Delay 0.2 detik sebelum restart
    }

    private void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        PlayButtonClickSound();
        Time.timeScale = 1f;
        if (bgm != null) bgm.Play();
        Invoke("LoadNextScene", 0.5f); // Delay 0.2 detik sebelum ke level berikutnya
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        PlayButtonClickSound();
        Time.timeScale = 1f;
        if (bgm != null) bgm.Play();
        Invoke("LoadMainMenu", 0.5f); // Delay 0.2 detik sebelum ke Main Menu
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("levelSelect");
    }

    public void QuitGame()
    {
        PlayButtonClickSound();
        Debug.Log("Quit Game");
        Invoke("ExitGame", 0.1f); // Delay sebelum keluar
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        PlayButtonClickSound();
        TogglePause();
    }

    private void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.PlayOneShot(buttonClickSound.clip); // Pastikan suara tetap terdengar
        }
    }
}
