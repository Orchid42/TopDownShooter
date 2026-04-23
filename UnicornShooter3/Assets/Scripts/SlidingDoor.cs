using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;

    public float openDistance = 1f;
    public float openSpeed = 2f;

    private Vector3 leftClosedPosition;
    private Vector3 rightClosedPosition;
    private Vector3 leftOpenPosition;
    private Vector3 rightOpenPosition;

    private bool isOpening = false;
    private bool isClosing = false;


    void Start()
    {
        leftClosedPosition = leftDoor.localPosition;
        rightClosedPosition = rightDoor.localPosition;

        leftOpenPosition = leftClosedPosition + Vector3.left * openDistance;
        rightOpenPosition = rightClosedPosition + Vector3.right * openDistance;
    }

    void Update()
    {
        if (isOpening)
        {
            leftDoor.localPosition = Vector3.Lerp(leftDoor.localPosition, leftOpenPosition, openSpeed * Time.deltaTime);
            rightDoor.localPosition = Vector3.Lerp(rightDoor.localPosition, rightOpenPosition, openSpeed * Time.deltaTime);
        }
        else if (isClosing)
        {
            leftDoor.localPosition = Vector3.Lerp(leftDoor.localPosition, leftClosedPosition, openSpeed * Time.deltaTime);
            rightDoor.localPosition = Vector3.Lerp(rightDoor.localPosition, rightClosedPosition, openSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOpening = true;
            isClosing = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOpening = false;
            isClosing = true;
        }
    }
}