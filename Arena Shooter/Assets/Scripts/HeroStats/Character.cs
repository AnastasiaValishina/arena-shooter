using System.Collections.Generic;
using UnityEngine;

namespace Arena.HeroStats
{
    [CreateAssetMenu(fileName = "Character", menuName = "Stats/New Character", order = 1)]
    public class Character : ScriptableObject
    {
        [SerializeField] HeroProgressionStat[] stats;

        Dictionary<HeroStat, float[]> lookupTable = null;

        public float GetStat(HeroStat stat, int level)
        {
            BuildLookup();

            float[] levels = lookupTable[stat];

            if (levels.Length < level)
            {
                return 0;
            }

            return levels[level - 1];
        }

        private void BuildLookup()
        {
            if (lookupTable != null) return;

            lookupTable = new Dictionary<HeroStat, float[]>();

            foreach (HeroProgressionStat progressionStat in stats)
            {
                lookupTable[progressionStat.stat] = progressionStat.levels;
            }
        }

        [System.Serializable]
        public class HeroProgressionStat
        {
            public HeroStat stat;
            public float[] levels;
        }
    }
}
