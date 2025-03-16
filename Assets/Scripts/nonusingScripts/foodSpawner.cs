using System.Collections;
using UnityEngine;

public class foodSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] foodPrefabs;
    [SerializeField]
    private float minSpawnTime = 1f;
    [SerializeField]
    private float maxSpawnTime = 3f;
    [SerializeField]
    private float autoFoodDestroyTime = 3f;

    private void Start()
    {
        StartCoroutine(SpawnFood());
    }
    private IEnumerator SpawnFood()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            GameObject spawnedFood = SpawnRandomFood();
            StartCoroutine(DestroyFoodAfterTime(spawnedFood, autoFoodDestroyTime));
        }
    }
    private GameObject GetRandomFood()
    {
        int randomFood = Random.Range(0, foodPrefabs.Length); 
        return foodPrefabs[randomFood];

    }
    private GameObject SpawnRandomFood()
    {
        int randomX = Random.Range(0, Grid.Instance.GridSize.x);
        int randomY = Random.Range(0, Grid.Instance.GridSize.y);

        Vector3 spawnPosition = Grid.Instance.GridToWorldPostition(new Vector2Int(randomX, randomY));

        GameObject foodToSpawn = GetRandomFood();
        GameObject spawnedFood  = Instantiate(foodToSpawn, spawnPosition, Quaternion.identity);

        return spawnedFood;
    }

    private IEnumerator DestroyFoodAfterTime(GameObject food, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (food != null) 
        {
            Destroy(food);
        }
    }

}
