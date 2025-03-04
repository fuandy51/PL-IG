using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;

    [Space(10)]
    [Header("Tombol UI")]
    [SerializeField] private Button PlayAgainButton;
    [SerializeField] private Button MainMenuButton;
    [SerializeField] private Button QuitButton;

    private void Start()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(false); // Sembunyikan panel kemenangan di awal
        }

        // Pastikan tombol tidak null sebelum menambahkan event
        if (PlayAgainButton != null) PlayAgainButton.onClick.AddListener(RestartLevel);
        if (MainMenuButton != null) MainMenuButton.onClick.AddListener(GoToMainMenu);
        if (QuitButton != null) QuitButton.onClick.AddListener(QuitGame);
    }

    public void ShowWinPanel()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true); // Tampilkan panel kemenangan
            Time.timeScale = 0; // Pause game
        }
    }

    private void RestartLevel()
    {
        Debug.Log("Restarting Level...");
        Time.timeScale = 1; // Resume game sebelum restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GoToMainMenu()
    {
        Debug.Log("Tombol Main Menu DITEKAN!"); // Debug untuk memastikan tombol diklik
        Time.timeScale = 1; // Resume game sebelum pindah scene
        SceneManager.LoadScene("LevelSelect"); // Pastikan LevelSelect ada di Build Settings
    }

    private void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
