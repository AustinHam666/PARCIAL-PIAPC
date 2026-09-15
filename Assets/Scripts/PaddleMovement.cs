using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PaddleMovement : MonoBehaviour
{
    [SerializeField] private KeyCode moveUpKey = KeyCode.W;
    [SerializeField] private KeyCode moveDownKey = KeyCode.S;
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float minY = -3.75f;
    [SerializeField] private float maxY = 3.75f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float verticalInput = 0f;

        if (Input.GetKey(moveUpKey))
        {
            verticalInput += 1f;
        }

        if (Input.GetKey(moveDownKey))
        {
            verticalInput -= 1f;
        }

        float newY = rb.position.y + verticalInput * moveSpeed * Time.fixedDeltaTime;
        newY = Mathf.Clamp(newY, minY, maxY);

        rb.MovePosition(new Vector2(rb.position.x, newY));
    }
}
