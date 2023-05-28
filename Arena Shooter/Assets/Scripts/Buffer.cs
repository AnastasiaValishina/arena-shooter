using System.Collections.Generic;
using UnityEngine;

public class Buffer : Enemy, IModifierProvider
{
    [SerializeField] float distanceToKeep;
    [SerializeField] float speedIncrease;

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
        transform.position = Vector2.MoveTowards(transform.position, target.position, -currentSpeed * Time.deltaTime);
    }

    public IEnumerable<float> GetAdditiveModifiers(EnemyStat stat)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<float> GetPercentageModifiers(EnemyStat stat)
    {
        if (stat == EnemyStat.Speed)
        {
            yield return speedIncrease;
        }
    }
}
