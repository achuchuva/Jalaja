using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // The enemy prefab to be spawned
    public float spawnRadius = 12f;  // Radius of the unit circle
    public float spawnRate = 0.4f;  // Time interval between spawns

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    void SpawnEnemy()
    {
        // Generate a random angle
        float angle = Random.Range(0f, Mathf.PI * 2);

        // Calculate the spawn position
        Vector2 spawnPosition = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * spawnRadius;

        // Instantiate the enemy at the spawn position with no rotation
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
