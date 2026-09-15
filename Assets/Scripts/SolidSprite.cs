using UnityEngine;

public static class SolidSprite
{
    private static Sprite cachedSprite;

    public static Sprite Get()
    {
        if (cachedSprite == null)
        {
            Texture2D texture = new Texture2D(1, 1);
            texture.SetPixel(0, 0, Color.white);
            texture.Apply();

            cachedSprite = Sprite.Create(texture, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f), 1f);
        }

        return cachedSprite;
    }
}
