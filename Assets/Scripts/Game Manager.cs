using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton agar bisa diakses dari WordDisplay
    public float fallSpeedMultiplier = 1.0f; // Multiplier default

    private void Awake()
    {
        // Pastikan hanya ada satu instance GameManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method untuk mengatur multiplier
    public void SetFallSpeedMultiplier(float multiplier)
    {
        fallSpeedMultiplier = multiplier;
    }
}
