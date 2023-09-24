using UnityEngine;

namespace Arena.HeroStats
{
    public class BaseStats : MonoBehaviour
    {
        [SerializeField] CharacterType characterType;        
        [SerializeField] Character progression = null;

        int _startingLevel = 1;
        int _currentLevel;
        int CurrentLevel
        {
            get
            {
                if (_currentLevel <= 0)
                {
                    return _startingLevel;
                }
                return _currentLevel;
            }
            set { }
        }

        public float GetStat(HeroStat stat)
        {
            var baseStat = GetBaseStat(stat);
            return baseStat + (GetPercentageModifier(stat) * baseStat / 100);
        }

        private float GetBaseStat(HeroStat stat)
        {
            return progression.GetStat(stat, CurrentLevel);
        }

        private float GetPercentageModifier(HeroStat stat)
        {
            return 0; // проверить надо ли
        }
    }

    public enum CharacterType
    {
        Melee,
        Archer,
        Bomber
    }
}
