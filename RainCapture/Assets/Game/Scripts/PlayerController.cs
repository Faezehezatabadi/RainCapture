
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f; 
    public float minX = -8f, maxX = 8f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearDamping = 5f;
    } 

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y); 

        rb.position = new Vector2(Mathf.Clamp(rb.position.x, minX, maxX), rb.position.y);
    }
}