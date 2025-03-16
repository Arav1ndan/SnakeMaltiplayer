using System.Collections;
using UnityEngine;

public class powerUpsSpanwer : MonoBehaviour
{
    [SerializeField]
    private GameObject[] powerUpPrefabs;
    [SerializeField]
    private float minSpawnTime = 5f;
    [SerializeField]
    private float maxSpawnTime = 10f;

    public Vector2Int gridSize; 

    void Start()
    {
        StartCoroutine(SpawnPowerUp());
    }

    IEnumerator SpawnPowerUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            Vector2 randomPosition = Grid.Instance.GetRandomGridPosition();
            int randomIndex = Random.Range(0, powerUpPrefabs.Length);

            Instantiate(powerUpPrefabs[randomIndex], randomPosition, Quaternion.identity);
        }
    }
}
