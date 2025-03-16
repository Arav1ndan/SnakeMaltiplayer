using UnityEngine;

public class Shield : Item
{
    [SerializeField]
    private float shieldDuration = 3f;
    
    public override void ApplyEffect(snakeController snake)
    {
        snake.ActivateShield(shieldDuration);
        Debug.Log("Shield Activated for " + shieldDuration + " seconds!");
        CollectItem();
    }
}
