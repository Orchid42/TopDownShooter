using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 8f;
    public float lifetime = 2f;
    public float damage = 1f;

    private Vector3 moveDirection;

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction;
    }

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Damageable damageable = collision.gameObject.GetComponent<Damageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}