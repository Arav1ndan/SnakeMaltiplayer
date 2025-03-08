using System.Collections;
using UnityEngine;

public class powerUps : MonoBehaviour
{
    public enum PowerItem { Shield, ScoreBoost, SpeedUp }

    [SerializeField] private float powerUpDuration = 3f;  // Default duration
    private snakeController snakeController;

    private void Start()
    {
        snakeController = FindObjectOfType<snakeController>(); // Get the snake reference
    }

    public void ActivatePowerUp(PowerItem powerItem)
    {
        //StartCoroutine(ApplyPowerUpEffect(powerItem));
    }

    //private IEnumerator ApplyPowerUpEffect(PowerItem powerItem)
    //{
    //    switch (powerItem)
    //    {
    //        case PowerItem.Shield:
    //            snakeController.isShieldActive = true;
    //            Debug.Log("Shield Activated!");
    //            yield return new WaitForSeconds(powerUpDuration);
    //            snakeController.isShieldActive = false;
    //            Debug.Log("Shield Deactivated!");
    //            break;

    //        case PowerItem.ScoreBoost:
    //            snakeController.isScoreBoostActive = true;
    //            Debug.Log("Score Boost Activated!");
    //            yield return new WaitForSeconds(powerUpDuration);
    //            snakeController.isScoreBoostActive = false;
    //            Debug.Log("Score Boost Ended!");
    //            break;

    //        case PowerItem.SpeedUp:
    //            float originalSpeed = snakeController.moveSpeed;
    //            snakeController.moveSpeed *= 1.5f; // Increase speed by 50%
    //            Debug.Log("Speed Boost Activated!");
    //            yield return new WaitForSeconds(powerUpDuration);
    //            snakeController.moveSpeed = originalSpeed;
    //            Debug.Log("Speed Boost Ended!");
    //            break;
    //    }
    //}
}
