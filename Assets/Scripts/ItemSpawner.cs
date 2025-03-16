using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itemPrefab;
    [SerializeField]
    private float spawnIntervals = 2f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnItem),5f,spawnIntervals);
    }

    void SpawnItem()
    {
        Vector2 randomPosition = Grid.Instance.GetRandomGridPosition();
        int randomIndex = Random.Range(0, itemPrefab.Length);

        Instantiate(itemPrefab[randomIndex], randomPosition, Quaternion.identity);
    }
}
