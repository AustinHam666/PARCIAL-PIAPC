using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int leftScore;
    [SerializeField] private int rightScore;

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterPoint(bool rightPlayerScored)
    {
        if (rightPlayerScored)
        {
            rightScore++;
        }
        else
        {
            leftScore++;
        }

        Debug.Log($"Punto anotado. Izquierda: {leftScore} - Derecha: {rightScore}");
    }
}
