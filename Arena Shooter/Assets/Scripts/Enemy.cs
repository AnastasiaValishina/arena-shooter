using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject[] boostersToSpawn;
    [Range(0, 100)] [SerializeField] int spawnChance = 30;

    Transform target;
    bool isQuitting;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;        
    }

    void Update()
    {
        if (target == null) return;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        if (!isQuitting)
        {
            SpawnBooster();
        }
    }

    private void SpawnBooster()
    {
        int randomInt = Random.Range(0, 100);
        if (randomInt < spawnChance)
        {
            GameObject randomBooster = boostersToSpawn[Random.Range(0, boostersToSpawn.Length)];
            Instantiate(randomBooster, transform.position, Quaternion.identity);
        }
    }

    void OnApplicationQuit()
    {
        isQuitting = true;
    }
}
