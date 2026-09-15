using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private float courtHalfWidth = 9f;

    private Rigidbody2D rb;
    private Vector3 startPosition;
    private Vector2 velocityBeforeCollision;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    private void Start()
    {
        LaunchInRandomDirection();
    }

    private void FixedUpdate()
    {
        velocityBeforeCollision = rb.velocity;
    }

    private void Update()
    {
        if (transform.position.x < -courtHalfWidth)
        {
            GameManager.Instance?.RegisterPoint(rightPlayerScored: true, goalPosition: transform.position);
            ResetBall();
        }
        else if (transform.position.x > courtHalfWidth)
        {
            GameManager.Instance?.RegisterPoint(rightPlayerScored: false, goalPosition: transform.position);
            ResetBall();
        }
    }

    public void ResetBall()
    {
        transform.position = startPosition;
        LaunchInRandomDirection();
    }

    private void LaunchInRandomDirection()
    {
        float directionX = Random.value < 0.5f ? -1f : 1f;
        float directionY = Random.Range(-0.5f, 0.5f);
        Vector2 direction = new Vector2(directionX, directionY).normalized;

        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 incoming = velocityBeforeCollision.sqrMagnitude > 0.01f ? velocityBeforeCollision : rb.velocity;
        Vector2 normal = collision.GetContact(0).normal;
        Vector2 reflected = Vector2.Reflect(incoming, normal);

        rb.velocity = reflected.normalized * speed;

        transform.position += (Vector3)(normal * 0.05f);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Vector2 normal = collision.GetContact(0).normal;
        transform.position += (Vector3)(normal * 0.02f);
    }
}
