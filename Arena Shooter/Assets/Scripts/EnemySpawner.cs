using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject enemyBossPrefab;
    [SerializeField] float minDelay, maxDelay;
    [SerializeField] SpawnPoint[] spawnPoints;    
    [SerializeField] Tilemap tilemap;

    float nextSpawnTime;
    BoundsInt bounds;

    public event Action onBufferSpawn;

    private void Start()
    {
        bounds = tilemap.cellBounds;
    }
    void Update()
    {
        SpawnEnemy();
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBoss();
        }
    }

    void SpawnEnemy()
    {
        if (Time.time > nextSpawnTime)
        {
            Instantiate(enemyPrefab, GetRandomPoint(), Quaternion.identity);
            nextSpawnTime = Time.time + UnityEngine.Random.Range(minDelay, minDelay);
            onBufferSpawn();
            Debug.Log("Enemy is spawned");
        }
    }

    void SpawnBoss()
    {
            Instantiate(enemyBossPrefab, GetRandomPoint(), Quaternion.identity);
            Debug.Log("Boss is spawned");
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

        var spawnPointIndex = UnityEngine.Random.Range(0, pointsInRange.Count - 1);
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

    private void OnDisable()
    {
        onBufferSpawn = null;
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
