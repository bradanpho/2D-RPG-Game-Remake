using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject enemyPrefab;
    public float spawnInterval = 5f;

    [Header("Spawn Area")]
    public float spawnRange = 3f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-spawnRange, spawnRange),
            Random.Range(-spawnRange, spawnRange),
            0
        );

        Instantiate(enemyPrefab, transform.position + randomOffset, Quaternion.identity);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRange);
    }

}
