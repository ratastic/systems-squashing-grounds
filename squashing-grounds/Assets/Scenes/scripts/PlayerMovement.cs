using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveForce = 1f;
    private Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        rb2d.linearVelocity = new Vector2(moveX * moveForce, moveY * moveForce);
    }
}
