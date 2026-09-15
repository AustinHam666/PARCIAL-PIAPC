using UnityEngine;

public static class CircleSprite
{
    private static Sprite cachedSprite;

    public static Sprite Get()
    {
        if (cachedSprite == null)
        {
            const int size = 64;
            Texture2D texture = new Texture2D(size, size)
            {
                filterMode = FilterMode.Bilinear,
                wrapMode = TextureWrapMode.Clamp
            };

            Vector2 center = new Vector2(size / 2f, size / 2f);
            float radius = size / 2f;

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    float distance = Vector2.Distance(new Vector2(x + 0.5f, y + 0.5f), center);
                    Color pixel = distance <= radius ? Color.white : new Color(1f, 1f, 1f, 0f);
                    texture.SetPixel(x, y, pixel);
                }
            }

            texture.Apply();

            cachedSprite = Sprite.Create(texture, new Rect(0, 0, size, size), new Vector2(0.5f, 0.5f), size);
        }

        return cachedSprite;
    }
}
