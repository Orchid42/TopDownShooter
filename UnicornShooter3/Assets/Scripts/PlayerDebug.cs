using UnityEngine;

public class PlayerDebug : MonoBehaviour
{

    public int testNumber = 5;
    public float moveSpeed = 1f;
    public Vector3 moveDirection = Vector3.right;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
