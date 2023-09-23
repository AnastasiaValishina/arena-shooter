using Arena.EnemyAttributes;
using Arena.HeroStats;
using UnityEngine;

public class JumpDamager : MonoBehaviour
{
    private float _jumpDamage;
    private float _jumpDamageArea;
    private float _critChance;
    private float _critBonus;

    private void Awake()
    {
        _jumpDamage = GetComponent<BaseStats>().GetStat(HeroStat.JumpDamage);
        _jumpDamageArea = GetComponent<BaseStats>().GetStat(HeroStat.DamageArea);
        _critChance = GetComponent<BaseStats>().GetStat(HeroStat.CritChance);
        _critBonus = GetComponent<BaseStats>().GetStat(HeroStat.CritBonus);
    }

    public void CauseDamage()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _jumpDamageArea);

        foreach (Collider2D collider in colliders)
        {
            if (collider.GetComponent<EnemyHealth>() != null)
            {
                collider.GetComponent<EnemyHealth>().TakeDamage(_jumpDamage);
            }
        }
    }
}
