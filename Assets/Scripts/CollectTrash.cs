using UnityEngine;
using UnityEngine.InputSystem;

public class CollectTrash : MonoBehaviour
{
    public GameObject myShade;
    private bool playerInRange = false;
    private PlayerMovement player;
    private Score getScore;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerMovement>();
            playerInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame && !player.Hide)
        {
            Destroy(gameObject);
            Destroy(myShade);
            getScore = FindFirstObjectByType<Score>();
            getScore.AddScore(200);
        }
    }
}
