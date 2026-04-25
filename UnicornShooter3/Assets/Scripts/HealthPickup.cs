using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healAmount = 25f;

    void Update()
    {
        transform.localScale = Vector3.one * (1f + Mathf.Sin(Time.time * 5f) * 0.1f);
        transform.position += Vector3.up * Mathf.Sin(Time.time * 3f) * 0.001f;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
                Destroy(gameObject);
            }
        }
    }
}
