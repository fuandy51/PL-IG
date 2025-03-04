using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private DragWithoutClick playerMovement;
    private LevelManager levelManager;

    [Space(10)]
    [Header("Tombol UI")]
    public Button PlayButton;
    public Button MainMenuButton;
    public Button QuitButton;

    [Space(10)]
    [Header("PauseMenu")]
    public GameObject PauseMenu;

    [Space(10)]
    [Header("Menu")]
    public GameObject Menu;

    [Space(10)]
    [Header("Audio")]
    [SerializeField] private AudioSource UIAudioSource;

    private void Awake()
    {
        playerMovement = player.GetComponent<DragWithoutClick>();
        PauseMenu.SetActive(false);
        Menu.SetActive(false);
        levelManager = FindObjectOfType<LevelManager>();

        // Menambahkan event listener untuk klik mouse
        PlayButton.onClick.AddListener(OnPlayButtonClicked);
        MainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        QuitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        UIAudioSource.Play();
        levelManager.Play();
    }

    private void OnMainMenuButtonClicked()
    {
        UIAudioSource.Play();
        levelManager.MainMenu();
        Time.timeScale = 1f;
    }

    private void OnQuitButtonClicked()
    {
        UIAudioSource.Play();
        Application.Quit();
    }

    public void ShowLoseMenu()
    {
        Debug.Log("Menampilkan Lose Menu!");
        if (Menu != null)
        {
            Menu.SetActive(true);
            Time.timeScale = 0; // Pause game
        }
    }
}
