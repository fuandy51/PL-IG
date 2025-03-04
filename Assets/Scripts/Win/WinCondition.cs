using TMPro;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] public static int toysCollected = 0;
    [SerializeField] public int winScore = 5; // Skor yang dibutuhkan untuk menang

    // Referensi UI
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject winPanel;

    private void Start()
    {
        // Inisialisasi tampilan awal
        UpdateScoreText();
        if (winPanel != null)
        {
            winPanel.SetActive(false); // Sembunyikan panel kemenangan di awal
        }
    }

    // Method untuk menambah skor
    public void AddToy()
    {
        toysCollected++;
        Debug.Log($"Toys Collected: {toysCollected}");

        // Perbarui UI teks
        WinCondition instance = FindObjectOfType<WinCondition>();
        if (instance != null)
        {
            instance.UpdateScoreText();
        }

        // Cek apakah pemain menang
        if (toysCollected >= instance.winScore)
        {
            Debug.Log("Player Wins! Congratulations!");
            instance.ShowWinPanel();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $" {toysCollected}/{winScore}";
        }
    }

    private void ShowWinPanel()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true); // Tampilkan panel kemenangan
            Time.timeScale = 0; // Pause game
            ResetGame();
        }
    }

    private void ResetGame()
    {
        // Reset skor
        toysCollected = 0;

        // Perbarui teks skor
        UpdateScoreText();

        Debug.Log("Game Reset: Score has been reset.");
    }

    public void TriggerWin()
    {
        Debug.Log("Triggering win condition directly!");

        // Tampilkan panel kemenangan
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0; // Pause game
        }

        // Reset skor dan perbarui UI
        ResetGame();
    }
}
