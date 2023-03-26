using UnityEngine;

public class EnemyBoss : Enemy
{
    [SerializeField] float distanceToKeep;
    [SerializeField] float speedIncrease;

    void Start()
    {
        SetTarget();
    }

    void Update()
    {
        if (InRangeOfPlayer())
        {
            MoveAway();
        }
        if (!InRangeOfPlayer())
        {
            MoveToTarget();
        }
    }

    private bool InRangeOfPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);
        return distanceToPlayer < distanceToKeep;
    }

    void MoveAway()
    {
        if (target == null) return;
        transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
    }
}
