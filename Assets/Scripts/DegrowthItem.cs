using UnityEngine;

public class DegrowthItem : Item
{
    [SerializeField]
    private int DegrowthAmout = 1;

    public override void ApplyEffect(snakeController snake)
    {
        snake.DecreaseLength(DegrowthAmout);
        CollectItem();
    }
}
