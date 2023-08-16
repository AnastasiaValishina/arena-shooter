using Arena.HeroStats;
using UnityEngine;

namespace Arena.HeroAttributes
{
    public class Health : MonoBehaviour
    {
        float _maxHP;
        public float HealthPoints { get; private set; }
        public float HpRegeneration { get; private set; }

        private float regenerationTimer;

        PlayerController controller;

        private void Awake()
        {
            controller = GetComponent<PlayerController>();
            _maxHP = GetComponent<HeroBaseStat>().GetStat(HeroStat.MaxHealth);
            HealthPoints = _maxHP;
            HpRegeneration = GetComponent<HeroBaseStat>().GetStat(HeroStat.HealthRegeneration);
        }

        private void Update()
        {
            if (HealthPoints == _maxHP) return;
            if (HealthPoints > _maxHP)
            {
                HealthPoints = _maxHP;
                return;
            }
            if (HpRegeneration <= 0) return;

            regenerationTimer += Time.deltaTime;
            if (regenerationTimer >= 1)
            {
                HealthPoints += HpRegeneration;
                regenerationTimer = 0;
            }
        }

        public void TakeDamage(float damage)
        {
            HealthPoints -= damage;

            controller.PlayHitAnimation();

            if (HealthPoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
