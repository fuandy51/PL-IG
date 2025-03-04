using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Menekan tombol L, mencoba load LevelSelect...");
            SceneManager.LoadScene("LevelSelect");
        }
    }
}
