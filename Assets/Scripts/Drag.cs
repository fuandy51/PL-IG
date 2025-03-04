using UnityEngine;

public class Drag : MonoBehaviour
{

    Vector2 difference = Vector2.zero;
    float initialY; // Menyimpan posisi awal di sumbu Y

    private void Start()
    {
        // Menyimpan posisi awal objek di sumbu Y
        initialY = transform.position.y;
    }

    private void OnMouseDown()
    {
        // Hitung selisih posisi saat klik
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        difference = mousePosition - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
        // Ambil posisi kursor saat ini
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Hanya ubah posisi di sumbu X, dengan mempertahankan sumbu Y tetap sama
        transform.position = new Vector3(mousePosition.x - difference.x, initialY, transform.position.z);
    }

}
