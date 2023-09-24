using Arena.EnemyStats;
using UnityEngine;

namespace Arena.EnemyAttributes
{
    public class EnemyHealth : MonoBehaviour
    {
        private float _healthPoints;

        private void Awake()
        {
            _healthPoints = GetComponent<EnemyBaseStats>().GetStat(EnemyStat.Health);
        }

        public void TakeDamage(float damage)
        {
            _healthPoints -= damage;
            if (_healthPoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
