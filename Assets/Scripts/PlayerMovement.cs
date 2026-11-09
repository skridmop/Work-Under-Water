using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public bool Hide = false;
    public Sprite normalsprite;
    public Sprite hiddensprite;

    private SpriteRenderer spriteRenderer;
    private Animator animHide;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animHide = GetComponent<Animator>();
    }

    void Update()
    {
        if (Keyboard.current.wKey.isPressed && !Hide)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Keyboard.current.sKey.isPressed && !Hide)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (Keyboard.current.aKey.isPressed && !Hide)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (Keyboard.current.dKey.isPressed && !Hide)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !Hide)
        {
            animHide.SetBool("Hide", true);
            Hide = true;
            spriteRenderer.sprite = hiddensprite;
            GetComponent<Collider2D>().enabled = false;
        }
        else if (Keyboard.current.spaceKey.wasPressedThisFrame && Hide)
        {
            animHide.SetBool("Hide", false);
            Hide = false;
            spriteRenderer.sprite = normalsprite;
            GetComponent<Collider2D>().enabled = true;
        }
    }
}