using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class UseCircleSprite : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = CircleSprite.Get();
    }
}
