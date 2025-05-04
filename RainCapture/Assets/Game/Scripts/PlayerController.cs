using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    public float minX = -8f, maxX = 8f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (spriteRenderer == null)
        {
            Debug.LogWarning("SpriteRenderer not found on Player or its children.");
        }
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, minX, maxX), rb.position.y);

        if (spriteRenderer != null)
        {
            if (move > 0.01f)
                spriteRenderer.flipX = false;
            else if (move < -0.01f)
                spriteRenderer.flipX = true;
        }
    }
}
