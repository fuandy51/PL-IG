using UnityEngine;

public class WinLoseTrial : MonoBehaviour
{
    [SerializeField] public GameObject winCanvas;
    [SerializeField] public GameObject loseCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5)){
            winCanvas.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            loseCanvas.SetActive(true);
        }
    }
}
