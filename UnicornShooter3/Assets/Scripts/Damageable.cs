using System.Collections;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float maxHealth = 3f;
    public float currentHealth;

    public float shakeDuration = 0.1f;
    public float shakeStrength = 0.05f;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Vector3 originalPosition;

    void Start()
    {
        currentHealth = maxHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        originalPosition = transform.position;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        StopAllCoroutines();
        StartCoroutine(DamageFeedback());

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    IEnumerator DamageFeedback()
    {
        float elapsed = 0f;

        spriteRenderer.color = Color.red;

        while (elapsed < shakeDuration)
        {
            float offsetX = Random.Range(-shakeStrength, shakeStrength);
            float offsetY = Random.Range(-shakeStrength, shakeStrength);

            transform.position = originalPosition + new Vector3(offsetX, offsetY, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
        spriteRenderer.color = originalColor;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
