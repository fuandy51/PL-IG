using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    public Words[] wordList;

    public static WordGenerator Instance;

    private void Awake()
    {
        Instance = this;
    }

    public Words GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        return wordList[randomIndex];
    }
}
