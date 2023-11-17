using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    
    void Update()
    {
        Move();
    }

    public void Initialize(Vector3 direction)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;

        // You can add more customization based on your game's requirements
    }

    void Move()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
