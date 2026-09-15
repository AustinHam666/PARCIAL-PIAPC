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
}
