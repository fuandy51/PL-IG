using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [Header("BGM")]
    [SerializeField] private AudioSource[] BGM;

    [Header("Player Control")]
    [SerializeField] private GameObject player;
    private DragWithoutClick playerMovement;

    [Header("UI Buttons")]
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button MainMenuButton;
    [SerializeField] private Button QuitButton;

    [Header("Pause Menu")]
    [SerializeField] private GameObject PauseMenu;

    [Header("Audio")]
    [SerializeField] private AudioSource UIAudioSource;
    [SerializeField] private AudioSource BGMAudioSource;

    private bool isPaused = false;

    private void Start()
    {
        // Pastikan Pause Menu tidak aktif saat game mulai
        PauseMenu.SetActive(false);

        // Cek komponen yang dibutuhkan
        if (player != null)
            playerMovement = player.GetComponent<DragWithoutClick>();

        // Tambahkan listener untuk tombol UI
        PlayButton.onClick.AddListener(Resume);
        MainMenuButton.onClick.AddListener(ReturnToMainMenu);
        QuitButton.onClick.AddListener(QuitGame);
    }

    private void Update()
    {
        // Jika tombol ESC ditekan, maka Pause atau Resume game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        Debug.Log("Resume ditekan!");
        UIAudioSource.Play();

        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        if (playerMovement != null)
            playerMovement.enabled = true;

        foreach (var bgm in BGM)
        {
            if (bgm != null)
                bgm.UnPause();
        }
    }

    public void Pause()
    {
        Debug.Log("Game Paused!");
        UIAudioSource.Play();

        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        if (playerMovement != null)
            playerMovement.enabled = false;

        foreach (var bgm in BGM)
        {
            if (bgm != null)
                bgm.Pause();
        }
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("Loading Main Menu...");
        UIAudioSource.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelect"); // Pastikan scene "LevelSelect" ada di Build Settings
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        UIAudioSource.Play();
        Application.Quit();
    }
}
