using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    public float moveDistance = 38f; // Distance the object will move
    public float moveSpeed = 1f; // Speed of the movement
    private Rigidbody rb;

    private float movementDuration = 3f;
    private float timer = 0f;
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 targetPos;
    private bool movingToEnd = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        endPos = new Vector3(transform.position.x, transform.position.y,20f);
        targetPos = endPos;
    }

    // Update is called once per frame
    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if it's time to switch movement direction
        if (timer >= movementDuration)
        {
            timer = 0f;
            targetPos = movingToEnd ? startPos : endPos;
            movingToEnd = !movingToEnd;
        }

        // Move the object towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPos, timer);
    }
}
