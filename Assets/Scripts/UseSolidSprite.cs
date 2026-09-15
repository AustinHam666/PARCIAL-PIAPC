using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class UseSolidSprite : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = SolidSprite.Get();
    }
}
