using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private snakeController snake;

    private void Start()
    {
        snake = GetComponent<snakeController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            snakeController otherSnake = collision.GetComponent<snakeController>();
            if (otherSnake != null)
            {
                ResolveCollision(snake, otherSnake);
            }
        }
    }

    private void ResolveCollision(snakeController snake1, snakeController snake2)
    {
        if (!snake1.IsAlive || !snake2.IsAlive) return; // Skip if already eliminated

        int score1 = ScoreManager.Instance.GetPlayerScore(snake1.playerID);
        int score2 = ScoreManager.Instance.GetPlayerScore(snake2.playerID);

        if (score1 > score2)
        {
            
            Debug.Log($"{snake1.playerID} wins!");
            GameOver.Instance.ShowGameOverPanel(snake1.playerID);
            snake2.Eliminate();
        }
        else if (score1 < score2)
        {
            
            Debug.Log($"{snake2.playerID} wins!");
            GameOver.Instance.ShowGameOverPanel(snake2.playerID );
            snake1.Eliminate();
        }
        else
        {
            snake1.Eliminate();
            snake2.Eliminate();
            Debug.Log("It's a tie! Both players are eliminated.");
            GameOver.Instance?.ShowGameOverPanel("No one (Tie)");
        }
    }
}
