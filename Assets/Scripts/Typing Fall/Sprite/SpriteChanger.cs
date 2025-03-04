using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // SpriteRenderer untuk GameObject ini
    public Sprite bubbleWithToy; // Sprite gelembung dengan mainan di dalamnya
    public Sprite toyOnly; // Sprite mainan saja

    private bool wordCompleted = false; // Menyimpan status apakah kata sudah selesai diisi

    // Fungsi untuk mengatur sprite awal
    private void Start()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = bubbleWithToy; // Atur sprite awal sebagai gelembung
    }
    public void CompleteWord(Sprite target) 
    {
        spriteRenderer.sprite = target;
    }

    // Dipanggil ketika kata sudah selesai diisi
    public void CompleteWord()
    {
        wordCompleted = true;
        Debug.Log("Haloooooo testing");
        ChangeToToy();
    }

    // Mengubah sprite menjadi mainan
    private void ChangeToToy()
    {
        if (wordCompleted)
        {
            spriteRenderer.sprite = toyOnly;
        }
    }
}
