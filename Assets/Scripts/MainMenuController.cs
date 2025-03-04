using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
    [Header("Start Button")]
    public Button PlayButton;

    [Header("Quit Button")]
    public Button QuitButton;

    [Header("LevelManager Reference")]
    public LevelManager levelManager; // Drag LevelManager here in the Inspector

    [Header("BGM")]
    [SerializeField] private AudioSource AudioBGM;

    [Space(10)]
    [SerializeField] private AudioSource UIAudioSource;

    private void Awake()
    {
        AudioBGM.Play();

        if (levelManager == null)
        {
            Debug.LogError("LevelManager belum diassign di Inspector!");
        }

        if (PlayButton != null)
        {
            PlayButton.onClick.AddListener(() => StartCoroutine(PlayWithDelay()));
        }
        else
        {
            Debug.LogError("PlayButton belum diassign di Inspector!");
        }

        if (QuitButton != null)
        {
            QuitButton.onClick.AddListener(() => StartCoroutine(QuitWithDelay()));
        }
        else
        {
            Debug.LogError("QuitButton belum diassign di Inspector!");
        }
    }

    private IEnumerator PlayWithDelay()
    {
        Debug.Log("Play Button Clicked!");
        UIAudioSource.Play();
        yield return new WaitForSeconds(0.5f); // Beri waktu 0.5 detik agar sound dapat terdengar
        levelManager.Play();
    }

    private IEnumerator QuitWithDelay()
    {
        Debug.Log("Quit Button Clicked!");
        UIAudioSource.Play();
        yield return new WaitForSeconds(0.5f);
        levelManager.Quit();
    }
}
