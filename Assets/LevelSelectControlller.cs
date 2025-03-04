using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelSelectController : MonoBehaviour
{
    [Header("Buttons for Level Selection")]
    public Button[] levelButtons; // Drag & drop semua tombol level di Inspector

    [Header("Sound Effects")]
    [SerializeField] private AudioSource UIAudioSource;

    private void Start()
    {
        if (levelButtons.Length < 15)
        {
            Debug.LogError("Pastikan semua 15 tombol level sudah ditambahkan ke array di Inspector!");
            return;
        }

        // Menambahkan event listener ke setiap tombol level
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i + 1; // Level dimulai dari 1, bukan 0
            levelButtons[i].onClick.AddListener(() => StartCoroutine(LoadLevelWithDelay(levelIndex)));
        }
    }

    private IEnumerator LoadLevelWithDelay(int levelIndex)
    {
        Debug.Log($"Level {levelIndex} diklik!");
        UIAudioSource.Play();
        yield return new WaitForSeconds(0.5f); // Beri waktu agar sound effect terdengar
        SceneManager.LoadScene("LEVEL " + levelIndex); // Pastikan scene memiliki nama "Level1", "Level2", dst.
    }
}
