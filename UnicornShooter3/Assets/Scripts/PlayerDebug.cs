using UnityEngine;

public class PlayerDebug : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Vector3 moveDirection;

    public GameObject projectilePrefab;
    public Transform firePoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");
        moveDirection.z = 0f;

        moveDirection = moveDirection.normalized;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        }
    }
}
