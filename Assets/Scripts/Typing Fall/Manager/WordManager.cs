using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    private bool hasActiveWord;
    private Word activeWord;

    public WordSpawner wordSpawner;
    public List<string> wordsToModify; // Daftar kata yang akan dihilangkan hurufnya
    public int wordModifyInterval = 3; // Setiap kata keberapa akan diubah
    public int maxRemoveCount = 2; // **Jumlah maksimal huruf yang bisa hilang**
    private int wordCount = 0;

    public void AddWord()
    {
        Words newWords = WordGenerator.Instance.GetRandomWord();
        string modifiedWord = newWords.wordLetter;

        // Cek apakah kata ini termasuk yang akan dimodifikasi
        if (wordsToModify.Contains(modifiedWord) && wordCount % wordModifyInterval == 0)
        {
            modifiedWord = RemoveRandomLetters(modifiedWord, maxRemoveCount);
        }

        WordDisplay wordDisplay = wordSpawner.SpawnWord(newWords);
        if (wordDisplay == null)
        {
            Debug.LogError("WordDisplay gagal diinstansiasi!");
            return;
        }

        Word word = new Word(newWords, wordDisplay, modifiedWord);
        words.Add(word);

        wordCount++;
    }

    private string RemoveRandomLetters(string word, int maxRemove)
    {
        if (word.Length <= 2) return word; // Jangan hilangkan huruf jika terlalu pendek

        char[] wordArray = word.ToCharArray();
        int removeCount = Random.Range(1, maxRemove + 1); // **Hilang 1 sampai maxRemove huruf**

        for (int i = 0; i < removeCount; i++)
        {
            int indexToRemove = Random.Range(0, wordArray.Length);
            while (wordArray[indexToRemove] == '_') // Hindari mengganti huruf yang sudah dihapus
            {
                indexToRemove = Random.Range(0, wordArray.Length);
            }
            wordArray[indexToRemove] = '_'; // Ganti huruf dengan underscore
        }

        return new string(wordArray);
    }

    private void ResetActiveWord()
    {
        if (activeWord != null)
        {
            Debug.Log($"Resetting active letter: {activeWord.word}");
        }
        else
        {
            Debug.Log("Resetting active letter: null or already destroyed");
        }

        activeWord = null;
        hasActiveWord = false;
    }

    private void Update()
    {
        if (hasActiveWord)
        {
            GameObject activeWordGameObject = activeWord?.GetGameObject();

            // Cek apakah GameObject sudah dihancurkan
            if (activeWord == null || activeWordGameObject == null)
            {
                Debug.LogWarning("Active word's GameObject sudah dihancurkan. Resetting active word.");
                ResetActiveWord();
                return;
            }
        }

        if (Input.anyKeyDown)
        {
            char letter = Input.inputString.Length > 0 ? char.ToUpper(Input.inputString[0]) : '\0';

            if (letter != '\0')
            {
                if (hasActiveWord)
                {
                    if (activeWord.GetNextLetter() == letter)
                    {
                        activeWord.TypeLetter();

                        if (activeWord.WordTyped())
                        {
                            GameObject wordGameObject = activeWord?.GetGameObject();
                            if (wordGameObject != null)
                            {
                                ColliderManager colliderManager = wordGameObject.GetComponentInChildren<ColliderManager>();
                                if (colliderManager != null)
                                {
                                    colliderManager.EnableDestruction();
                                }
                            }

                            words.Remove(activeWord);
                            ResetActiveWord();
                        }
                    }
                }
                else
                {
                    foreach (Word word in words)
                    {
                        if (word.GetNextLetter() == letter)
                        {
                            activeWord = word;
                            hasActiveWord = true;
                            word.TypeLetter();
                            break;
                        }
                    }
                }
            }
        }
    }
}
