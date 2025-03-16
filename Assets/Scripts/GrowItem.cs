using UnityEngine;

public class GrowItem : Item
{
    [SerializeField]
    private int growAmout = 1;
    [SerializeField]
    private int scorePoint = 10;
    public override void ApplyEffect(snakeController snake)
    {
        snake.IncreaseLength(growAmout);
        string playerID = snake.playerID;
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(playerID, scorePoint);
        }
        Debug.Log("Snake Grew!");
        CollectItem();
    }
}
