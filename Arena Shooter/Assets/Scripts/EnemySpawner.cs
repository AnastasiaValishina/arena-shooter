using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float minDelay, maxDelay;
    [SerializeField] Transform[] spawnPoints;
    float nextSpawnTime;

    void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (Time.time > nextSpawnTime)
        {
            Instantiate(enemyPrefab, GetRandomPosition(), Quaternion.identity);
            nextSpawnTime = Time.time + Random.Range(minDelay, minDelay);
        }
    }

    Vector2 GetRandomPosition()
    {
        var spawnPointIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[spawnPointIndex].position;
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.GetChild(i).position, 0.3f);
        }
    }
}
