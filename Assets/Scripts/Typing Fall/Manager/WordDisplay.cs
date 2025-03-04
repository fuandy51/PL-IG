using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
    public TMP_Text text;
    public float fallSpeed = 0.5f; // Base speed

    public Words words;

    private SpriteRenderer spriteRenderer;
    private ParticleSystem particleSystem;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = words.sprite1;
        }

        particleSystem = Instantiate(words.particleEffect, transform);
        particleSystem.Stop();
    }

    public void SetWord(string word)
    {
        text.text = word;
    }

    public void RemoveLetter()
    {
        if (text.text[0] == '_')
        {
            text.text = text.text.Remove(0, 1); // Hapus underscore jika ada
        }
        else
        {
            text.text = text.text.Remove(0, 1);
        }

        text.color = Color.red;

        if (string.IsNullOrEmpty(text.text))
        {
            CompleteWord();
        }
    }

    private void CompleteWord()
    {
        Debug.Log("Word completed and triggering sprite change.");

        if (spriteRenderer != null && spriteRenderer.sprite == words.sprite1)
        {
            spriteRenderer.sprite = words.sprite2;
        }

        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }

    private void Update()
    {
        float adjustedSpeed = fallSpeed * GameManager.Instance.fallSpeedMultiplier;
        transform.Translate(0f, -adjustedSpeed * Time.deltaTime, 0f);
    }
}
