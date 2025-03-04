using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform wordCanvas;

    public WordDisplay SpawnWord(Words words)
    {
        Vector3 randomPosition = new Vector3(Random.Range(-8.45f, 8.39f), 7f);

        GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);

        // Tetapkan tag dari objek `Words` ke root dan semua children
        SetTagRecursively(wordObj, words.tag);

        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
        return wordDisplay;
    }

    private void SetTagRecursively(GameObject obj, string tag)
    {
        // Tetapkan tag ke objek utama
        obj.tag = tag;

        // Tetapkan tag ke semua children
        foreach (Transform child in obj.transform)
        {
            SetTagRecursively(child.gameObject, tag);
        }
    }
}