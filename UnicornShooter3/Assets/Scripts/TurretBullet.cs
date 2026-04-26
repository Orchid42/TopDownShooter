using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    public float speed = 8f;
    public int damage = 1;

    private Vector2 direction;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;
        rb.linearVelocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.collider.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }

        if (!collision.collider.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}