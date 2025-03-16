using UnityEngine;

public class BoostScore : Item
{
    [SerializeField]
    private int ScoreMultiplier = 2;

    public override void ApplyEffect(snakeController snake)
    {
        snake.IncreaseScore(ScoreMultiplier);
        CollectItem();
    }
}
