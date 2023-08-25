using UnityEngine;

namespace Arena.HeroStats
{
    public class BaseStats : MonoBehaviour
    {
        [SerializeField] int startingLevel = 1;

        [SerializeField] Character progression = null;

        int _currentLevel;
        int CurrentLevel
        {
            get
            {
                if (_currentLevel <= 0)
                {
                    return startingLevel;
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
}
