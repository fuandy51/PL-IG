using UnityEngine;

public class WordTimer : MonoBehaviour
{

    public WordManager wordManager;

    public float wordDelay = 0.0001f; // Tetap konstan
    private float nextWordTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Inisialisasi waktu awal
        nextWordTime = Time.time + wordDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextWordTime)
        {
            wordManager.AddWord();
            nextWordTime = Time.time + wordDelay; // Tidak mengubah wordDelay
        }
    }
}