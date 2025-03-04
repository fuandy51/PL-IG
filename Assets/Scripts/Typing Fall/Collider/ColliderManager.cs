using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    public Collider2D collider2D; // Collider yang digunakan
    public string playerTag = "Player"; // Tag untuk mendeteksi pemain
    public string destroyTag = "Destroy"; // Tag untuk mendeteksi objek penghancur
    private bool wordCompleted = false; // Status apakah kata telah diisi sepenuhnya
    private bool isPopped = false; // Status apakah objek sudah "pecah"

    private WinCondition winCondition; // Referensi ke WinCondition
    private Health health;
    private GameObject player;
    private CircleCollider2D circleCollider;

    private void Start()
    {
        // Inisialisasi collider jika belum diassign
        if (collider2D == null)
        {
            collider2D = GetComponent<Collider2D>();
        }

        // Mencari Player di scene
        player = GameObject.Find("Player");
        if (player != null)
        {
            health = player.GetComponent<Health>();
            if (health == null)
            {
                Debug.LogWarning("Health component NOT found on Player!");
            }
        }
        else
        {
            Debug.LogWarning("Player NOT found in the scene!");
        }

        // Inisialisasi CircleCollider2D
        circleCollider = GetComponent<CircleCollider2D>();
        if (circleCollider == null)
        {
            Debug.LogWarning("CircleCollider2D NOT found on this GameObject!");
        }

        GameObject winControllerObject = GameObject.Find("WinController");
        if (winControllerObject != null)
        {
            winCondition = winControllerObject.GetComponent<WinCondition>();
            if (winCondition == null)
            {
                Debug.LogWarning("WinCondition component NOT found on WinController!");
            }
        }
        else
        {
            Debug.LogWarning("WinController NOT found in the scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"OnTriggerEnter2D with {other.gameObject.name}, wordCompleted: {wordCompleted}");

        if (other.CompareTag(playerTag))
        {
            if (CompareTag("Toy"))
            {
                if (wordCompleted)
                {
                    Debug.Log("Toy collected by Player!");

                    // Tambahkan poin menggunakan Singleton WinCondition
                    if (winCondition != null)
                    {
                        winCondition.AddToy();
                    }

                    // Hancurkan objek setelah dikoleksi
                    DestroyParentOrSelf();
                }
                else
                {
                    Debug.LogWarning("Cannot collect toy. World is not completed!");
                }
            }

            if (CompareTag("Stone"))
            {
                health?.ReduceHealth();
            }
        }

        if (CompareTag("Pendopo")) // Kondisi untuk tag Pendopo
        {
            if (wordCompleted) // Jika jawaban sudah diberikan
            {
                Debug.Log("Player completed the Pendopo interaction!");

                if (winCondition != null)
                {
                    winCondition.TriggerWin(); // Langsung memicu kondisi kemenangan
                }
            }
            else
            {
                Debug.LogWarning("Player cannot complete Pendopo without answering!");
            }
        }

        if (other.CompareTag(destroyTag))
        {
            DestroyParentOrSelf();
            health?.ReduceHealth();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log($"OnTriggerStay2D with {other.gameObject.name}, wordCompleted: {wordCompleted}");

        if (other.CompareTag(playerTag))
        {
            if (CompareTag("Toy"))
            {
                if (wordCompleted)
                {
                    Debug.Log("Toy collected by Player!");

                    // Tambahkan poin menggunakan Singleton WinCondition
                    if (winCondition != null)
                    {
                        winCondition.AddToy();
                    }

                    // Hancurkan objek setelah dikoleksi
                    DestroyParentOrSelf();
                }
                else
                {
                    Debug.LogWarning("Cannot collect toy. World is not completed!");
                }
            }

            if (CompareTag("Stone"))
            {
                health?.ReduceHealth();
            }
        }

        if (CompareTag("Pendopo")) // Kondisi untuk tag Pendopo
        {
            if (wordCompleted) // Jika jawaban sudah diberikan
            {
                Debug.Log("Player completed the Pendopo interaction!");

                if (winCondition != null)
                {
                    winCondition.TriggerWin(); // Langsung memicu kondisi kemenangan
                }
            }
            else
            {
                Debug.LogWarning("Player cannot complete Pendopo without answering!");
            }
        }

        if (wordCompleted && other.CompareTag(playerTag))
        {
            ExecuteDestruction();
            ResetWordCompleted();
        }
    }

    public void EnableDestruction()
    {
        if (!wordCompleted)
        {
            wordCompleted = true;
            Debug.Log("wordCompleted set to true.");
        }
    }

    private void ResetWordCompleted()
    {
        wordCompleted = false;
        Debug.Log("wordCompleted reset to false.");
    }

    private void DestroyParentOrSelf()
    {
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject); // Hancurkan GameObject parent
        }
        else
        {
            Destroy(gameObject); // Jika tidak ada parent, hancurkan GameObject ini
        }
    }

    private void ExecuteDestruction()
    {
        DestroyParentOrSelf();
    }
}
