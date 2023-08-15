using UnityEngine;

namespace Arena.HeroStats
{
    public class HeroBaseStat : MonoBehaviour
    {
        [Range(1, 99)]
        [SerializeField] int startingLevel = 1;
        [SerializeField] HeroClass characterClass;
        [SerializeField] HeroProgression progression = null;

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
            return progression.GetStat(characterClass, stat, CurrentLevel);
        }

        private float GetPercentageModifier(HeroStat stat)
        {
            return 0; // проверить надо ли
        }
    }
}
