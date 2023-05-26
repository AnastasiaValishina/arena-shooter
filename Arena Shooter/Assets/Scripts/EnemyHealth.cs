using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float healthPoints;

    private void Awake()
    {
        healthPoints = GetComponent<EnemyBaseStats>().GetStat(EnemyStat.Health);
        Debug.Log(healthPoints);
    }

    public void DealDamage(int damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}