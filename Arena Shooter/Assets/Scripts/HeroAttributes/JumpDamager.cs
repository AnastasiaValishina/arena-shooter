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
            BaseStats baseStats = GetComponent<BaseStats>();
            _jumpDamage = baseStats.GetStat(HeroStat.JumpDamage);
            _jumpDamageArea = baseStats.GetStat(HeroStat.DamageArea);
            _critChance = baseStats.GetStat(HeroStat.CritChance);
            _critBonus = baseStats.GetStat(HeroStat.CritBonus);
            _abilityRadius = baseStats.GetStat(HeroStat.AbilityRadius);
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

        // Knockback - ������ ���������� �� ���� ������� ������������� �����.����� ����� � ���� ���� ������� ��������
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

        // Slowing - ������ ���������� � ������� ������������ �����.����� ����� � ���� ���� ������� ��������
        // Taunt -  ������ ���������� � ������� ����������� ����� � ������. ����� ����� � ���� ���� ������� ��������.

    }
}

