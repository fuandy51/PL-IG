using TMPro;
using UnityEngine;

public class Typer : MonoBehaviour
{
    public TextMeshProUGUI wordOutput = null; // Output to display the word
    public string targetWord = "example";    // The specific word to type

    private string remainingWord = string.Empty;

    private void Start()
    {
        SetWord(targetWord); // Set the target word at the start
    }

    private void SetWord(string newWord)
    {
        remainingWord = newWord;
        wordOutput.text = remainingWord;
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if (keysPressed.Length == 1)
            {
                EnterLetter(keysPressed);
            }
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            RemoveLetter();

            if (IsWordComplete())
            {
                OnWordComplete();
            }
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        remainingWord = remainingWord.Remove(0, 1);
        wordOutput.text = remainingWord;
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }

    private void OnWordComplete()
    {
        Debug.Log("Word completed: " + targetWord);
        // You can add logic here for what happens when the word is completed.
    }
}
