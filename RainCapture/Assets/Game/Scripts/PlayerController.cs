
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;       // سرعت حرکت
    public float minX = -8f, maxX = 8f; // محدوده حرکت افقی

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 5f; // باعث میشه خیلی لیز نخوره
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal"); // چپ و راست گرفتن از کیبورد
        rb.velocity = new Vector2(move * speed, rb.velocity.y); // حرکت دادن پلیر

        // جلوگیری از خروج پلیر از صفحه
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, minX, maxX), rb.position.y);
    }
}