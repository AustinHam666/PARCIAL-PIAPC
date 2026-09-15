using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int leftScore;
    [SerializeField] private int rightScore;
    [SerializeField] private int scoreToWin = 10;

    [Header("UI (asignar en el Inspector)")]
    [SerializeField] private Text leftScoreText;
    [SerializeField] private Text rightScoreText;

    [Header("Efectos (asignar en el Inspector)")]
    [SerializeField] private GameObject goalExplosionPrefab;
    [SerializeField] private BallMovement ball;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void RegisterPoint(bool rightPlayerScored, Vector3 goalPosition)
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

        SpawnGoalExplosion(goalPosition);
        UpdateScoreUI();

        if (leftScore >= scoreToWin || rightScore >= scoreToWin)
        {
            ResetMatch();
        }
    }

    private void SpawnGoalExplosion(Vector3 position)
    {
        if (goalExplosionPrefab != null)
        {
            Instantiate(goalExplosionPrefab, position, Quaternion.identity);
        }
    }

    private void UpdateScoreUI()
    {
        if (leftScoreText != null)
        {
            leftScoreText.text = leftScore.ToString();
        }

        if (rightScoreText != null)
        {
            rightScoreText.text = rightScore.ToString();
        }
    }

    private void ResetMatch()
    {
        Debug.Log($"Fin de la partida. Gana {(leftScore >= scoreToWin ? "izquierda" : "derecha")}. Reiniciando marcador.");

        leftScore = 0;
        rightScore = 0;
        UpdateScoreUI();

        if (ball != null)
        {
            ball.ResetBall();
        }
    }
}
