using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    public Transform player;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float detectionRange = 8f;
    public float fireRate = 1.5f;

    private float fireTimer;

    void Update()
    {
        if (player == null)
        {
            return;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            FacePlayer();

            fireTimer -= Time.deltaTime;

            if (fireTimer <= 0f)
            {
                Shoot();
                fireTimer = fireRate;
            }
        }
    }

    void FacePlayer()
    {
        if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            firePoint.localPosition = new Vector3(-Mathf.Abs(firePoint.localPosition.x), firePoint.localPosition.y, firePoint.localPosition.z);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            firePoint.localPosition = new Vector3(Mathf.Abs(firePoint.localPosition.x), firePoint.localPosition.y, firePoint.localPosition.z);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        TurretBullet bulletScript = bullet.GetComponent<TurretBullet>();

        if (bulletScript != null)
        {
            Vector2 direction = (player.position - firePoint.position).normalized;
            bulletScript.SetDirection(direction);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
