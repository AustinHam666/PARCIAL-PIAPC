using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BallTrailEffect : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 0.04f;
    [SerializeField] private float ghostLifetime = 0.25f;

    private SpriteRenderer sourceRenderer;
    private float timer;

    private void Awake()
    {
        sourceRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnGhost();
        }
    }

    private void SpawnGhost()
    {
        GameObject ghost = new GameObject("BallTrailGhost");
        ghost.transform.position = transform.position;
        ghost.transform.rotation = transform.rotation;
        ghost.transform.localScale = transform.localScale;

        SpriteRenderer ghostRenderer = ghost.AddComponent<SpriteRenderer>();
        ghostRenderer.sprite = sourceRenderer.sprite;
        ghostRenderer.color = new Color(1f, 1f, 1f, 0.4f);
        ghostRenderer.sortingOrder = sourceRenderer.sortingOrder - 1;

        ghost.AddComponent<FadeAndDestroy>().Initialize(ghostLifetime);
    }
}
