using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;
    public Words words;
    private int typeIndex;
    private string displayedWord;
    private WordDisplay display;

    public Word(Words _word, WordDisplay _display, string modifiedWord)
    {
        words = _word;
        word = words.wordLetter;
        displayedWord = modifiedWord; // Kata yang mungkin sudah dimodifikasi
        typeIndex = 0;
        display = _display;

        if (display == null)
        {
            Debug.LogError("WordDisplay tidak ditemukan untuk kata: " + word);
            return;
        }

        display.SetWord(displayedWord);
        display.words = _word;
    }

    public bool WordTyped()
    {
        return typeIndex >= word.Length;
    }

    public char GetNextLetter()
    {
        if (typeIndex < word.Length)
        {
            return word[typeIndex]; // Huruf asli, bukan huruf yang hilang
        }
        else
        {
            Debug.LogWarning($"GetNextLetter out-of-bounds: {typeIndex} for word: '{word}'");
            return '\0';
        }
    }

    public void TypeLetter()
    {
        if (typeIndex < word.Length)
        {
            display.RemoveLetter();
            typeIndex++;
        }
        else
        {
            Debug.Log($"TypeLetter out-of-bounds for word: '{word}'");
        }
    }

    public GameObject GetGameObject()
    {
        if (display == null || display.gameObject == null)
        {
            Debug.LogWarning("WordDisplay sudah dihancurkan atau null.");
            return null;
        }
        return display.gameObject;
    }

    
}
