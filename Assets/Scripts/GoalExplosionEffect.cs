using UnityEngine;

public static class GoalExplosionEffect
{
    private const int PieceCount = 14;
    private const float PieceSpeed = 6f;
    private const float PieceLifetime = 0.5f;
    private const float PieceScale = 0.5f;

    public static void SpawnAt(Vector3 position, Sprite sprite)
    {
        for (int i = 0; i < PieceCount; i++)
        {
            float angle = (360f / PieceCount) * i * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f);

            GameObject piece = new GameObject("GoalExplosionPiece");
            piece.transform.position = position;
            piece.transform.localScale = Vector3.one * PieceScale;

            SpriteRenderer renderer = piece.AddComponent<SpriteRenderer>();
            renderer.sprite = sprite;
            renderer.color = Color.yellow;
            renderer.sortingOrder = 10;

            piece.AddComponent<FadeAndDestroy>().Initialize(PieceLifetime, direction * PieceSpeed);
        }
    }
}
