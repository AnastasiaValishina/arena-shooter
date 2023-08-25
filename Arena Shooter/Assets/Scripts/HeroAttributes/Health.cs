using Arena.HeroStats;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Arena.HeroAttributes
{
    public class Health : MonoBehaviour
    {
        float _maxHP;
        float _armor;
        float _dodgeChance;

        float DodgeChance
        {
            get { return _dodgeChance; }
            set
            {
                if (value > 60)
                {
                    _dodgeChance = 60;
                }
                else { _dodgeChance = value; }
            }
        }
        public float HealthPoints { get; private set; }
        public float HpRegeneration { get; private set; }

        private float regenerationTimer;

        PlayerController controller;

        private void Awake()
        {
            controller = GetComponent<PlayerController>();
            BaseStats baseStats = GetComponent<BaseStats>();
            _maxHP = baseStats.GetStat(HeroStat.MaxHealth);
            HealthPoints = _maxHP;
            HpRegeneration = baseStats.GetStat(HeroStat.HealthRegeneration);
            _armor = baseStats.GetStat(HeroStat.Armor);
            DodgeChance = baseStats.GetStat(HeroStat.Dodge);
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
            if (!IsDodged()) return;
            if (controller.IsJumping) return;

            damage -= _armor;
            if (damage < 1) 
                damage = 1;

            HealthPoints -= damage;

            controller.PlayHitAnimation();

            if (HealthPoints <= 0)
            {
                Destroy(gameObject);
            }
        }

        bool IsDodged()
        {
            int chance = Random.Range(0, 100);
            return chance <= DodgeChance ? true : false;
        }
    }
}
