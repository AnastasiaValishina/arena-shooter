using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float minDelay, maxDelay;
    [SerializeField] SpawnPoint[] spawnPoints;    
    [SerializeField] Tilemap tilemap;

    float nextSpawnTime;
    BoundsInt bounds;

    private void Start()
    {
        bounds = tilemap.cellBounds;
    }
    void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (Time.time > nextSpawnTime)
        {
            Instantiate(enemyPrefab, GetRandomPoint(), Quaternion.identity);
            nextSpawnTime = Time.time + Random.Range(minDelay, minDelay);
        }
    }

    Vector2 GetRandomPoint()
    {
        MarkPointsInRange();

        List<SpawnPoint> pointsInRange = new List<SpawnPoint>();

        foreach (SpawnPoint point in spawnPoints)
        {
            if (point.IsInRange())
            {
                pointsInRange.Add(point);
            }
        }

        var spawnPointIndex = Random.Range(0, pointsInRange.Count - 1);
        var randomPoint = pointsInRange[spawnPointIndex];

        return randomPoint.transform.position;
    }

    private void MarkPointsInRange()
    {
        foreach (SpawnPoint point in spawnPoints)
        {
            point.CheckIfInRange(bounds);
        }
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
