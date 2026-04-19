using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 8f;
    public float lifetime = 2f;

    void Start()
    {
        Destroy(gameObject, lifetime); 
    }

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
