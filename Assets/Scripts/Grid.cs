using UnityEngine;

public class Grid : MonoBehaviour
{
  public static Grid Instance { get; private set; }
    private float cellSize = 1f;
    private Vector3 originPosition = Vector3.zero;
    [SerializeField]
    private Vector2Int gridSize = new Vector2Int(10, 10);

    public Vector2Int GridSize => gridSize;

    private void Awake()
    {
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    public Vector3 GridToWorldPostition(Vector2Int gridPosition)
    {
        float x = gridPosition.x * cellSize + originPosition.x + cellSize / 2f;
        float y = gridPosition.y * cellSize + originPosition.y + cellSize / 2f;

        return new Vector3(x, y, 0f);
    }
    public Vector2Int WorldToGridPosition(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt((worldPosition.x - originPosition.x) / cellSize);
        int y = Mathf.FloorToInt((worldPosition.y - originPosition.y) / cellSize);
        return new Vector2Int(x, y);
    }
    //public Vector2Int GetRandomGridPosition()
    //{
    //    int x = Random.Range(0, GridSize.x);
    //    int y = Random.Range(0, GridSize.y);

    //    Vector3 spawnPosistion = GridToWorldPostition(new Vector2Int(x, y));
    //    return spawnPosistion;
    //}
    public Vector3 GetRandomGridPosition()
    {
        int x = Random.Range(0, GridSize.x);
        int y = Random.Range(0, GridSize.y);

        Vector2Int randomGridPosition = new Vector2Int(x, y);
        return GridToWorldPostition(randomGridPosition);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector3 worldPos = GridToWorldPostition(new Vector2Int(x, y));
                Gizmos.DrawWireCube(worldPos, Vector3.one * cellSize);
            }
        }
    }
}
