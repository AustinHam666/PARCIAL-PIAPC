using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] private KeyCode moveUpKey = KeyCode.W;
    [SerializeField] private KeyCode moveDownKey = KeyCode.S;
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float minY = -3.75f;
    [SerializeField] private float maxY = 3.75f;

    private void Update()
    {
        float verticalInput = 0f;

        if (Input.GetKey(moveUpKey))
        {
            verticalInput += 1f;
        }

        if (Input.GetKey(moveDownKey))
        {
            verticalInput -= 1f;
        }

        Vector3 position = transform.position;
        position.y += verticalInput * moveSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;
    }
}
