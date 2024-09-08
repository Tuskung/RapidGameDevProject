using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region Editor Settings
    [SerializeField] private GameObject enemyPrefab;  // Reference to the enemy prefab
    [SerializeField] private Transform[] spawnPoints; // List of spawn points (assign in Inspector)
    [SerializeField] private float spawnRate = 3f;    // Time between enemy spawns
    [SerializeField] private float spawnDelay = 2f;   // Delay before starting to spawn
    [SerializeField] private int maxEnemies = 10;     // Maximum number of enemies that can be spawned
    #endregion

    #region Private Fields
    private int currentEnemyCount = 0;  // Tracks the number of enemies spawned
    #endregion

    #region Unity Callbacks
    private void Start()
    {
        // Start the spawning coroutine with a delay
        StartCoroutine(SpawnEnemies());
    }
    #endregion

    #region Methods
    private IEnumerator SpawnEnemies()
    {
        // Wait for the initial delay before starting to spawn
        yield return new WaitForSeconds(spawnDelay);

        // Keep spawning until the max number of enemies is reached
        while (currentEnemyCount < maxEnemies)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnRate); // Wait for the spawn rate time before next spawn
        }
    }

    private void SpawnEnemy()
    {
        if (spawnPoints.Length == 0) return; // Safety check if no spawn points are defined

        // Randomly pick a spawn point from the available points
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate the enemy at the chosen spawn point
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        // Ensure the enemy is not a child of the spawner
        enemy.transform.SetParent(null);

        // Increase the enemy count
        currentEnemyCount++;
    }
    #endregion
}
