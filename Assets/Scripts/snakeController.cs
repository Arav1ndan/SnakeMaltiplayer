using System.Collections.Generic;
using UnityEngine;


public class snakeController : MonoBehaviour
{

    public GameObject SneakHead;
    private List<Vector2Int> snakeBody = new List<Vector2Int>();
    private List<GameObject> SnakeBodyObj = new List<GameObject>();
    private Vector2Int snakeDirection; //= Vector2Int.right;

    public string playerID;
    public bool IsAlive { get; private set; } = true;

    private float moveTimer = 0;
    public float moveRate = 0.2f;


    private bool isShieldActive = false;
    private int score = 0;

    private void Start()
    {
        if (playerID == "Player1")
            snakeDirection = Vector2Int.right;  
        else if (playerID == "Player2")
            snakeDirection = Vector2Int.left;   

    }
   

    private void Update()
    {
        HandleInput();
        moveTimer += Time.deltaTime;
        if (moveTimer >= moveRate)
        {
            Move();
            moveTimer = 0f;
        }
    }
    void HandleInput()
    {
        if (playerID == "Player1") // Player 1 Controls (WASD)
        {
            if (Input.GetKey(KeyCode.W)) snakeDirection = Vector2Int.up;
            if (Input.GetKey(KeyCode.S)) snakeDirection = Vector2Int.down;
            if (Input.GetKey(KeyCode.A)) snakeDirection = Vector2Int.left;
            if (Input.GetKey(KeyCode.D)) snakeDirection = Vector2Int.right;
        }
        else if (playerID == "Player2") // Player 2 Controls (Arrow Keys)
        {
            if (Input.GetKey(KeyCode.UpArrow)) snakeDirection = Vector2Int.up;
            if (Input.GetKey(KeyCode.DownArrow)) snakeDirection = Vector2Int.down;
            if (Input.GetKey(KeyCode.LeftArrow)) snakeDirection = Vector2Int.left;
            if (Input.GetKey(KeyCode.RightArrow)) snakeDirection = Vector2Int.right;
        }
    }
    void Move()
    {
        if (snakeBody.Count == 0)
        {
            Debug.LogWarning("snakeBody was empty, initializing with head position.");
            Vector2Int headPosition = Grid.Instance.WorldToGridPosition(transform.position);
            snakeBody.Add(headPosition);
            return;
        }

        Vector2Int newHeadPosition = snakeBody[0] + snakeDirection;

        if (newHeadPosition.x < 0) newHeadPosition.x = Grid.Instance.GridSize.x - 1;
        if (newHeadPosition.x >= Grid.Instance.GridSize.x) newHeadPosition.x = 0;
        if (newHeadPosition.y < 0) newHeadPosition.y = Grid.Instance.GridSize.y - 1;
        if (newHeadPosition.y >= Grid.Instance.GridSize.y) newHeadPosition.y = 0;

        // Move the snake
        snakeBody.Insert(0, newHeadPosition);
     
        if (snakeBody.Count > 1)
            snakeBody.RemoveAt(snakeBody.Count - 1);

        transform.position = Grid.Instance.GridToWorldPostition(newHeadPosition);
        
        if (SnakeBodyObj.Count < snakeBody.Count - 1)
        {
            GameObject newBodyPart = Instantiate(SneakHead, transform.position, Quaternion.identity);
            SnakeBodyObj.Add(newBodyPart);
        }

        for (int i = 0; i < SnakeBodyObj.Count && i + 1 < snakeBody.Count; i++)
        {
            SnakeBodyObj[i].transform.position = Grid.Instance.GridToWorldPostition(snakeBody[i + 1]);
        }
    }
    public void IncreaseLength(int amount)
    {
        if (snakeBody.Count == 0) return; 

        Vector2Int lastBodyPart = snakeBody[snakeBody.Count - 1]; // Get last body part

        for (int i = 0; i < amount; i++)
        {
            snakeBody.Add(lastBodyPart);

            // Instantiate body object
            GameObject newBodyPart = Instantiate(SneakHead, Grid.Instance.GridToWorldPostition(lastBodyPart), Quaternion.identity);
    
            SnakeBodyObj.Add(newBodyPart);            
        }
    }

    public void DecreaseLength(int amount)
    {
        if (snakeBody.Count <= 1) return;

        int removeCount = Mathf.Min(amount, snakeBody.Count - 1); // Only remove body parts

        // Remove tail elements from snakeBody list
        snakeBody.RemoveRange(snakeBody.Count - removeCount, removeCount);

        // Destroy corresponding body objects
        for (int i = 0; i < removeCount && SnakeBodyObj.Count > 0; i++)
        {
            GameObject lastPart = SnakeBodyObj[SnakeBodyObj.Count - 1]; // Get last body part
            if (!isShieldActive)
            {
                SnakeBodyObj.RemoveAt(SnakeBodyObj.Count - 1); // Remove from list
                Destroy(lastPart); // Destroy the GameObject 
            }
                   
        }
    }

    public bool CanShrink()
    {
        return snakeBody.Count > 1;
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Tail"))
        {
            Debug.Log("snake has eaten tail...");
        }
    }
    public void IncreaseSpeed(float multiplier, float duration)
    {
        moveRate *= multiplier;
        Invoke(nameof(ResetSpeed), duration);
    }
    private void ResetSpeed()
    {
        moveRate = .2f; 
    }
    public void IncreaseScore(int amount)
    {
        score += amount;
        Debug.Log("Current Score: " + score);
    }
    public void ActivateShield(float duration)
    {
        if (!isShieldActive)
        {
            isShieldActive = true;
            Debug.Log("Shield is ON");
          
            Invoke(nameof(DeactivateShield), duration);
        }
    }
    private void DeactivateShield()
    {
        isShieldActive = false;
        Debug.Log("Shield is OFF");
       
    }
    public void Eliminate()
    {
        IsAlive = false;
        gameObject.SetActive(false); // Disable the player
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isShieldActive && collision.CompareTag("Obstacle"))
        {
            Debug.Log("Shield Protected the Snake!");
            return;  
        }

        Item item = collision.GetComponent<Item>();
        if (item != null)
        {
            item.ApplyEffect(this);
        }
    }
}
