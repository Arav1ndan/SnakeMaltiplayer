using UnityEngine;

public class SpeedBoost : Item
{
    [SerializeField]
    private float speedMultiplier = .1f;

    public override void ApplyEffect(snakeController snake)
    {
        snake.IncreaseSpeed(speedMultiplier, duration);
        CollectItem();
    }

}
