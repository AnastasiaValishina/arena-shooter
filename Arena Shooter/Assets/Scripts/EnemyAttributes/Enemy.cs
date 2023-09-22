using UnityEngine;
using Arena.EnemySpawning;
using Arena.EnemyStats;
using Arena.HeroAttributes;

namespace Arena.EnemyAttributes
{
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
            Health playerHealth = other.GetComponent<Health>();
            //if (target.IsDead()) return;

            playerHealth.TakeDamage(damage);
            nextHitTime = Time.time + timeBetweenHits;
        }

        private void OnEnable() { FindObjectOfType<EnemySpawner>().onBufferSpawn += UpdateSpeed; }

        private void OnDisable() 
        {
            var spawner = FindObjectOfType<EnemySpawner>();

            if (spawner != null) 
                spawner.onBufferSpawn -= UpdateSpeed; 
        }

        protected void SetTarget()
        {
            target = GameObject.FindWithTag("Player").transform;
        }

        private void UpdateSpeed()
        {
            currentSpeed = GetComponent<EnemyBaseStats>().GetStat(EnemyStat.Speed);
        }

        protected void MoveToTarget()
        {
            if (target == null) return;
            transform.position = Vector2.MoveTowards(transform.position, target.position, currentSpeed * Time.deltaTime);
        }
    }
}

