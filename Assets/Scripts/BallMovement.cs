using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour
{
    [SerializeField] private float speed = 7f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
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
        Vector2 incoming = rb.velocity;
        Vector2 normal = collision.GetContact(0).normal;
        Vector2 reflected = Vector2.Reflect(incoming, normal);

        rb.velocity = reflected.normalized * speed;
    }
}
