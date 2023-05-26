using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    //[SerializeField] protected float speed = 1;
    [SerializeField] GameObject[] boostersToSpawn;
    [Range(0, 100)] [SerializeField] int spawnChance = 30;

    protected Transform target;
    bool isQuitting;

    protected float currentSpeed;
    // берем скорость из бейз стат +
    // проверяем +
    // баффер
    // обновить скорость у всех
    // убить бафера

    private void Awake()
    {
        UpdateSpeed();
    }

    void Start()
    {
        SetTarget();
    }

    void Update()
    {
        MoveToTarget();
    }

    private void OnEnable()
    {
        FindObjectOfType<EnemySpawner>().onBufferSpawn += UpdateSpeed;
    }

    private void OnDisable()
    {
        FindObjectOfType<EnemySpawner>().onBufferSpawn -= UpdateSpeed;
    }

    protected void SetTarget()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    private void UpdateSpeed()
    {
        currentSpeed = GetComponent<EnemyBaseStats>().GetStat(EnemyStat.Speed);
        Debug.Log(name + " updated speed to " + currentSpeed);
    }

    protected void MoveToTarget()
    {
        if (target == null) return;
        transform.position = Vector2.MoveTowards(transform.position, target.position, currentSpeed * Time.deltaTime);
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

/*    public void ChangeSpeed(float increasePercent)
    {
        speed = speed + (speed * increasePercent / 100);
    }*/

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
