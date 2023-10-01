using Arena.EnemyAttributes;
using Arena.HeroStats;
using UnityEngine;

namespace Arena.HeroAttributes
{
    public class JumpDamager : MonoBehaviour
    {
        private float _jumpDamage;
        private float _jumpDamageArea;
        private float _critChance;
        private float _critBonus;
        private float _abilityRadius;

        private void Awake()
        {
            Stats stats = GetComponent<Stats>();
            _jumpDamage = stats.GetJumpDamage();
            _jumpDamageArea = stats.GetDamageArea();
            _critChance = stats.GetCritChance();
            _critBonus = stats.GetCritBonus();
            _abilityRadius = stats.GetAbilityRadius();
        }

        public void CauseDamage()
        {
            KnockBack();
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _jumpDamageArea);
            float totalDamage = GetCritDamage();

            foreach (Collider2D collider in colliders)
            {
                if (collider.GetComponent<EnemyHealth>() != null)
                {
                    collider.GetComponent<EnemyHealth>().TakeDamage(totalDamage);
                }
            }
        }

        private float GetCritDamage()
        {
            float damage = _jumpDamage;
            int randomIndex = Random.Range(0, 100);

            if (randomIndex > _critChance)
                damage *= _critBonus;

            return damage;
        }

        public void KnockBack()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _abilityRadius);
            foreach (Collider2D collider in colliders )
            {      
                Enemy enemy = collider.GetComponent<Enemy>();
                if (enemy != null)
                    enemy.KnockBack(_abilityRadius, transform.position);                
            }
        }

/*        public void SlowEnemies()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _abilityRadius);
            foreach (Collider2D collider in colliders)
            {
                Enemy enemy = collider.GetComponent<Enemy>();
                if (enemy != null)
                    enemy.Slowdown(_abilityRadius, transform.position);
            }
        }*/
        // Slowing - Радиус окружности в которой замендляются враги.Центр круга в мете куда прыгнул персонаж
        // Taunt -  Радиус окружности в которой стягиваются враги к центру. Центр круга в мете куда прыгнул персонаж.

    }
}

