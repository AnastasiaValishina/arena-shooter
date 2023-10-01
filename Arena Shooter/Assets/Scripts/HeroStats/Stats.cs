using System;
using UnityEngine;

namespace Arena.HeroStats
{
    public class Stats : MonoBehaviour
    {
        [SerializeField] CharacterType characterType;        
        [SerializeField] CharacterStats progression = null;

        // ссылка на конфиг - progression (надо переименьвать)
        // увеличение статов персонажа

        public float GetHealth()
        {
            return progression.GetHealth();
        }
        public float GetHealthRegeneration()
        {
            return progression.GetHealthRegeneration();
        }
        public float GetArmor()
        {
            return progression.GetArmor();
        }
        public float GetDodge()
        {
            return progression.GetDodge();
        }
        public float GetDamage()
        {
            return progression.GetDamage();
        }
        public float GetMoveSpeed()
        {
            return progression.GetMoveSpeed();
        }
        public float GetExpGain()
        {
            return progression.GetExpGain();
        }
        public float GetMagnetRadius()
        {
            return progression.GetMagnetRadius();
        }
        public float GetJumpDamage()
        {
            return progression.GetJumpDamage();
        }
        public float GetDamageArea()
        {
            return progression.GetDamageArea();
        }
        public float GetCooldown()
        {
            return progression.GetCooldown();
        }
        public int GetJumpsInRow()
        {
            return progression.GetJumpsInRow();
        }
        public float GetAbilityRadius()
        {
            return progression.GetAbilityRadius();
        }
        public float GetCritChance()
        {
            return progression.GetCritChance();
        }
        public float GetCritBonus()
        {
            return progression.GetCritBonus();
        }
    }

    public enum CharacterType
    {
        Melee,
        Archer,
        Bomber
    }
}
