using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodController : MonoBehaviour
{
    public enum FoodType { MassGainer, MassBurner }
    [SerializeField]
    private FoodType m_foodType;
    [SerializeField]
    private int sizeChange = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player passed through" + collision.name);

        if(collision.CompareTag("Player"))
        {
            Debug.Log("player went thorugh the food!");
            snakeController snake = collision.GetComponent<snakeController>();
            if (snake)
            {
                Debug.Log("sn");
                if (m_foodType == FoodType.MassGainer) {
                    snake.IncreaseLength(sizeChange);
                    Debug.Log("snake eat" + FoodType.MassGainer + name);
                }
                  
                
                else if(m_foodType == FoodType.MassBurner && snake.CanShrink())
                    snake.DecreaseLength(sizeChange);

                Destroy(gameObject);
            }
        }
    }
}
