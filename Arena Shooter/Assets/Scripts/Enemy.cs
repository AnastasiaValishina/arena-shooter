using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float timeBetweenHits = 1f;

    protected Transform target;
    protected float currentSpeed;
    protected float damage = 0;

    float nextHitTime;

    private void Awake()
    {
        SetTarget();
        UpdateSpeed();
        damage = GetComponent<EnemyBaseStats>().GetStat(EnemyStat.Damage);
    }

    void Update()
    {
        MoveToTarget();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Time.time < nextHitTime) return;
        if (other.transform != target) return;
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        //if (target.IsDead()) return;

        playerHealth.TakeDamage(damage);
        nextHitTime = Time.time + timeBetweenHits;
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
        //Debug.Log(name + " updated speed to " + currentSpeed);
    }

    protected void MoveToTarget()
    {
        if (target == null) return;
        transform.position = Vector2.MoveTowards(transform.position, target.position, currentSpeed * Time.deltaTime);
    }
}
