using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Transform target;
    protected float currentSpeed;

    private void Awake()
    {
        SetTarget();
        UpdateSpeed();
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
}
