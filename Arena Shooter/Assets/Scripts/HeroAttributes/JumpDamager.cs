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
}
