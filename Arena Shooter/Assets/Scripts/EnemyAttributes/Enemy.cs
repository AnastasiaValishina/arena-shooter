using Arena.EnemySpawning;
using Arena.EnemyStats;
using Arena.HeroAttributes;
using System.Collections;
using UnityEngine;

namespace Arena.EnemyAttributes
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] float timeBetweenHits = 1f;
        [SerializeField] float knockbackDuration = 0.5f;

        protected Transform target;
        protected float currentSpeed;
        protected float damage = 0;

        private float nextHitTime;

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

        public void KnockBack(float radius, Vector2 sender)
        {
            StopAllCoroutines();
            StartCoroutine(MoveFrom(radius, sender));
        }
        private IEnumerator MoveFrom(float radius, Vector2 senderPosition)
        {
            Vector2 startPosition = transform.position;
            Vector2 direction = (startPosition - senderPosition).normalized;
            Vector2 targetPosition = senderPosition + direction * radius;

            float timeElapsed = 0;
            
            while (timeElapsed < knockbackDuration)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / knockbackDuration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.position = targetPosition;
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

