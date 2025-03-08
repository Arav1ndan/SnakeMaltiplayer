using UnityEngine;

public class foodController : MonoBehaviour
{
    public enum FoodType { MassGainer, MassBurner }
    [SerializeField]
    private FoodType m_foodType;
    [SerializeField]
    private int sizeChange = 1;
    [SerializeField]
    private ScoreController scoreController;

    private void Start()
    {
        scoreController = FindObjectOfType<ScoreController>();
        if (scoreController == null )
        {
            Debug.Log("score controller is attached correctely");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player passed through" + collision.name);

        if(collision.CompareTag("Player"))
        {
            Debug.Log("player went thorugh the food!");
            snakeController snake = collision.GetComponent<snakeController>();
            if (snake)
            {
              
                if (m_foodType == FoodType.MassGainer) {
                    snake.IncreaseLength(sizeChange);
                 scoreController.IncreaseScore(10);
                    Debug.Log("snake eat" + FoodType.MassGainer + name);
                }                
                else if(m_foodType == FoodType.MassBurner && snake.CanShrink())
                {
                    snake.DecreaseLength(sizeChange);
                    scoreController.DecreaseScore(10);
                }   
                Destroy(gameObject);
            }
        }
    }
}
