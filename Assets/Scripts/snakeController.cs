using System.Collections.Generic;
using UnityEngine;


public class snakeController : MonoBehaviour
{

    public GameObject SneakHead;
    private List<Vector2Int> snakeBody = new List<Vector2Int>();
    private List<GameObject> SnakeBodyObj = new List<GameObject>();
    private Vector2Int snakeDirection = Vector2Int.right;

    private float moveTimer = 0;
    public float moveRate = 0.2f;

    private void Start()
    {
        //Vector2Int startPosition = new Vector2Int(Grid.Instance.GridSize.x / 2, Grid.Instance.GridSize.y / 2);
        //snakeBody.Add(startPosition);
        //transform.position = Grid.Instance.GridToWorldPostition(startPosition);
  
        
            if (snakeBody.Count == 0) // If snakeBody is empty, add the head's position
            {
                Vector2Int headPosition = Grid.Instance.WorldToGridPosition(transform.position);
                snakeBody.Add(headPosition);
            }
        
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
        if (Input.GetKeyDown(KeyCode.W)) snakeDirection = Vector2Int.up;
        if (Input.GetKeyDown(KeyCode.S)) snakeDirection = Vector2Int.down;
        if (Input.GetKeyDown(KeyCode.A)) snakeDirection = Vector2Int.left;
        if (Input.GetKeyDown(KeyCode.D)) snakeDirection = Vector2Int.right;
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
        //snakeBody.RemoveAt(snakeBody.Count - 1); // Remove tail
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

        //snakeBody.RemoveAt(snakeBody.Count - 1);
    }
    public void IncreaseLength(int amount)
    {
        //for (int i = 0; i < amount; i++)
        //{
        //    snakeBody.Add(snakeBody[snakeBody.Count - 1]);
        //}
        if (snakeBody.Count == 0) return; // Prevent invalid access

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
        //if (snakeBody.Count > amount)
        //{
        //    snakeBody.RemoveRange(snakeBody.Count - amount, amount);

        //}
        if (snakeBody.Count <= 1) return; // Ensure head is not removed

        int removeCount = Mathf.Min(amount, snakeBody.Count - 1); // Only remove body parts

        // Remove tail elements from snakeBody list
        snakeBody.RemoveRange(snakeBody.Count - removeCount, removeCount);

        // Destroy corresponding body objects
        for (int i = 0; i < removeCount && SnakeBodyObj.Count > 0; i++)
        {
            GameObject lastPart = SnakeBodyObj[SnakeBodyObj.Count - 1]; // Get last body part
            SnakeBodyObj.RemoveAt(SnakeBodyObj.Count - 1); // Remove from list
            Destroy(lastPart); // Destroy the GameObject
        }
    }

    public bool CanShrink()
    {
        return snakeBody.Count > 1;
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("tail"))
        {
            Debug.Log("snake has eaten tail...");
        }
    }
}
