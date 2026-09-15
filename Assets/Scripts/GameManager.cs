using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int leftScore;
    [SerializeField] private int rightScore;
    [SerializeField] private int scoreToWin = 10;
    [SerializeField] private BallMovement ball;

    private void Awake()
    {
        Instance = this;
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

        if (leftScore >= scoreToWin || rightScore >= scoreToWin)
        {
            ResetMatch();
        }
    }

    private void SpawnGoalExplosion(Vector3 position)
    {
        if (ball == null)
        {
            return;
        }

        SpriteRenderer ballRenderer = ball.GetComponent<SpriteRenderer>();
        if (ballRenderer != null && ballRenderer.sprite != null)
        {
            GoalExplosionEffect.SpawnAt(position, ballRenderer.sprite);
        }
    }

    private void ResetMatch()
    {
        Debug.Log($"Fin de la partida. Gana {(leftScore >= scoreToWin ? "izquierda" : "derecha")}. Reiniciando marcador.");

        leftScore = 0;
        rightScore = 0;

        if (ball != null)
        {
            ball.ResetBall();
        }
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle
        {
            fontSize = 48,
            alignment = TextAnchor.UpperCenter,
            fontStyle = FontStyle.Bold
        };
        style.normal.textColor = Color.white;

        GUI.Label(new Rect(Screen.width * 0.25f - 60, 60, 120, 60), leftScore.ToString(), style);
        GUI.Label(new Rect(Screen.width * 0.75f - 60, 60, 120, 60), rightScore.ToString(), style);
    }
}
