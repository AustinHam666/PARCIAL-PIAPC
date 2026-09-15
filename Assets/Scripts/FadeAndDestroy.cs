using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FadeAndDestroy : MonoBehaviour
{
    private float duration;
    private float elapsed;
    private Vector3 velocity;
    private Vector3 startScale;
    private Color startColor;
    private SpriteRenderer spriteRenderer;

    public void Initialize(float lifetime, Vector3 velocity = default)
    {
        duration = lifetime;
        this.velocity = velocity;
        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
        startScale = transform.localScale;
    }

    private void Update()
    {
        elapsed += Time.deltaTime;
        float t = Mathf.Clamp01(elapsed / duration);

        transform.position += velocity * Time.deltaTime;
        transform.localScale = startScale * (1f - t);

        Color fadedColor = startColor;
        fadedColor.a = startColor.a * (1f - t);
        spriteRenderer.color = fadedColor;

        if (t >= 1f)
        {
            Destroy(gameObject);
        }
    }
}
