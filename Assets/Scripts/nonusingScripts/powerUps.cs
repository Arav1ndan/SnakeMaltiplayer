using System.Collections;
using UnityEngine;

public class powerUps : MonoBehaviour
{
    public enum PowerItem { Shield, ScoreBoost, SpeedUp }
    [SerializeField]
    private PowerItem powerItem;
    private snakeController snakeController;
    private ScoreController scoreController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player passed through" + collision.name);

        if (collision.CompareTag("Player"))
        {
            Debug.Log("player went thorugh the powerUps!");
            snakeController snake = collision.GetComponent<snakeController>();
            if (snake)
            {

                //switch (powerItem)
                //{
                //    case PowerItem.Shield:
                //        snakeController.ActivateShield(3f);
                //        Debug.Log("snake when thorugh shield");
                //        break;

                //    case PowerItem.ScoreBoost:
                //        snake.ActivateScoreBoost(3f);
                //        break;
                //    case PowerItem.SpeedUp:
                //        snake.ActivateSpeedBoost(3f, 2f);
                //        break;
                //}
            }
        }
    }
}





