using UnityEngine;

public class WordManager2 : MonoBehaviour
{
    public static WordManager2 instance;

    public ObjectDataSO[] wordPrefab;
    public Transform wordCanvas;

    private void Awake()
    {
        instance = this;
    }

    public WordDisplay GetWordObject()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-8.45f, 8.39f), 7f);
        int randomObject = Random.Range(0, wordPrefab.Length);

        GameObject wordObj = Instantiate(wordPrefab[randomObject].objectPrefab, randomPosition, Quaternion.identity);
        wordObj.GetComponentInChildren<SpriteRenderer>().sprite = wordPrefab[randomObject].bubbleSprite;

        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
        return wordDisplay;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
