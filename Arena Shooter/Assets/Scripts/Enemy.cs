using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed = 1;
    [SerializeField] GameObject[] boostersToSpawn;
    [Range(0, 100)] [SerializeField] int spawnChance = 30;

    protected Transform target;
    bool isQuitting;

    void Start()
    {
        SetTarget();
    }

    protected void SetTarget()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        MoveToTarget();
    }

    protected void MoveToTarget()
    {
        if (target == null) return;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
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

    public void ChangeSpeed(float increasePercent)
    {
        speed = speed + (speed * increasePercent / 100);
    }

    private void OnDestroy()
    {
        if (!isQuitting)
        {
            SpawnBooster();
        }
    }

    void OnApplicationQuit()
    {
        isQuitting = true;
    }
}
