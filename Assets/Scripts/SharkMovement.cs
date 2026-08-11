using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SharkMovement : MonoBehaviour
{
    public Vector3 position;
    public float sharkSpeed = 5f;

    public float clock = 0f;
    public float clockLimit = 2f;

    private bool canCheck = false;
    private Vector3 startPosition;
    private bool isHidden;
    private float t;


    void Start()
    {
        startPosition = transform.position;
        StartCoroutine(MoveShark());
    }
    void Update()
    {
        if (canCheck)
        {
            Vector3 playerPosition = FindFirstObjectByType<PlayerMovement>().transform.position;
            isHidden = FindFirstObjectByType<PlayerMovement>().Hide;
            if (!isHidden && t < 0.8f)
            {
                position = playerPosition;
                clockLimit = 1.5f;
            }
        }
        clock += Time.deltaTime;
        t = clock / clockLimit;
        transform.position = Vector3.Lerp(startPosition, position, t);
        if (t >= 1f && isHidden)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isHidden)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }


    IEnumerator MoveShark()
    {
        yield return new WaitForSeconds(1f);
        canCheck = true;
    }
}
