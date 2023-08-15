using System.Collections.Generic;
using UnityEngine;

namespace Arena.HeroStats
{
    [CreateAssetMenu(fileName = "Hero Progression", menuName = "Stats/New Hero Progression", order = 1)]
    public class HeroProgression : ScriptableObject
    {
        [SerializeField] HeroProgressionClass[] heroClasses;

        Dictionary<HeroClass, Dictionary<HeroStat, float[]>> lookupTable = null;

        public float GetStat(HeroClass heroClass, HeroStat stat, int level)
        {
            BuildLookup();

            float[] levels = lookupTable[heroClass][stat];

            if (levels.Length < level)
            {
                return 0;
            }

            return levels[level - 1];
        }

        private void BuildLookup()
        {
            if (lookupTable != null) return;

            lookupTable = new Dictionary<HeroClass, Dictionary<HeroStat, float[]>>();

            foreach (HeroProgressionClass heroProgressionClass in heroClasses)
            {
                var statLookupTable = new Dictionary<HeroStat, float[]>();
                foreach (HeroProgressionStat progressionStat in heroProgressionClass.stats)
                {
                    statLookupTable[progressionStat.stat] = progressionStat.levels;
                }
                lookupTable[heroProgressionClass.heroClass] = statLookupTable;
            }
        }

        public int GetLevels(HeroClass heroType, HeroStat stat)
        {
            BuildLookup();

            float[] levels = lookupTable[heroType][stat];

            return levels.Length;
        }

        [System.Serializable]
        class HeroProgressionClass
        {
            public HeroClass heroClass;
            public HeroProgressionStat[] stats;
        }

        [System.Serializable]
        public class HeroProgressionStat
        {
            public HeroStat stat;
            public float[] levels;
        }
    }
}
