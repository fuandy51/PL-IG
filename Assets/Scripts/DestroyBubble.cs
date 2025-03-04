using UnityEngine;

public class DestroyBubble : MonoBehaviour
{
    private bool isPopped = false;
    private CircleCollider2D circleCollider;

    private Health health;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        if (player != null)
        {
            //Debug.Log("Player found: " + player.name);

            // Cek apakah komponen Health ditemukan pada Player
            health = player.GetComponent<Health>();
            if (health != null)
            {
                //Debug.Log("Health component found on Player.");
            }
            else
            {
                //Debug.Log("Health component NOT found on Player!");
            }
        }
        else
        {
            //Debug.Log("Player NOT found in the scene!");
        }

        // Cek apakah CircleCollider2D ditemukan pada GameObject ini
        circleCollider = GetComponent<CircleCollider2D>();
        if (circleCollider != null)
        {
            //Debug.Log("CircleCollider2D found on this GameObject: " + gameObject.name);
        }
        else
        {
            //Debug.Log("CircleCollider2D NOT found on this GameObject!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"Triggered by: {collision.gameObject.name} with tag {collision.tag}");
        if (collision.CompareTag("Destroy"))
        {
            //Debug.Log("Object collided with 'Destroy' tag.");
            Destroy(transform.parent.gameObject);
            health.ReduceHealth();
            //Debug.Log("Parent object destroyed.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (isPopped)
            {
                //add score
            }
            else
            {
                circleCollider.isTrigger = true;
            }
        }
    }
}
