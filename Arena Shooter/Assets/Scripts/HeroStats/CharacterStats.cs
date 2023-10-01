using UnityEngine;

namespace Arena.HeroStats
{
    [CreateAssetMenu(fileName = "Character", menuName = "Stats/New Character", order = 1)]
    public class CharacterStats : ScriptableObject
    {
        [Header("MainStats")]

        [SerializeField] float maxHealth;
        [SerializeField] float healthRegeneration;
        [SerializeField] float armor;
        [SerializeField] float dodge;
        [SerializeField] float moveSpeed;
        [SerializeField] int expGain;
        [SerializeField] float magnetRadius;

        [Header("Weapon")]
        [SerializeField] float damage;
        [SerializeField] float weaponMaxRange;

        [Header("Jumping")]
        [SerializeField] float jumpDuration;
        [SerializeField] float jumpDamage;
        [SerializeField] float damageArea;
        [SerializeField] int cooldown;
        [SerializeField] int jumpsInRow;
        [SerializeField] float abilityRadius;
        [SerializeField] int critChance;
        [SerializeField] float critBonus;

        public float GetHealth() => maxHealth;
        public float GetHealthRegeneration() => healthRegeneration;
        public float GetArmor() => armor;
        public float GetDodge() => dodge;
        public float GetMoveSpeed() => moveSpeed;
        public int GetExpGain() => expGain;
        public float GetDamage() => damage;
        public float GetMagnetRadius() => magnetRadius;
        public float GetWeaponMaxRange() => weaponMaxRange;
        public float GetJumpDuration() => jumpDuration;
        public float GetJumpDamage() => jumpDamage;
        public float GetDamageArea() => damageArea;
        public int GetCooldown() => cooldown;
        public int GetJumpsInRow() => jumpsInRow;
        public float GetAbilityRadius() => abilityRadius;
        public int GetCritChance() => critChance;
        public float GetCritBonus() => critBonus;
    }
}
