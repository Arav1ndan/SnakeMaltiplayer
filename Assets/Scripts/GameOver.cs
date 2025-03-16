using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public static GameOver Instance { get; private set; }

    [SerializeField]
    private GameObject GameOverPanel;

    [SerializeField]
    private TextMeshProUGUI gameOverText;

    public void ShowGameOverPanel(string winner)
    {
        if (GameOverPanel != null)
        {
            GameOverPanel.SetActive(true);
        }
        if (gameOverText != null)
        {
            gameOverText.text = winner + " Wins!";
        }
    }
}
