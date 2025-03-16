using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private int player1Score = 0;
    private int player2Score = 0;

    public bool isMultiplayer = false;
    [SerializeField] private TextMeshProUGUI player1ScoreText;
    [SerializeField] private TextMeshProUGUI player2ScoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(string playerID, int points)
    {
        if (playerID == "Player1")
        {
            player1Score += points;
            UpdateScoreUI();
        }
        else if (isMultiplayer && playerID == "Player2")
        {
            player2Score += points;
            UpdateScoreUI();
        }
    }
    private void UpdateScoreUI()
    {
        if (player1ScoreText != null)
            player1ScoreText.text = "Player1 Score: " + player1Score;

        if (isMultiplayer && player2ScoreText != null)
            player2ScoreText.text = "Player2 Score: " + player2Score;
    }
    public int GetPlayerScore(string playerID)
    {
        return playerID == "Player1" ? player1Score : (isMultiplayer ? player2Score : 0);
    }
}
