using System.Collections.Generic;
using UnityEngine;

namespace Arena.EnemyStats
{
    [CreateAssetMenu(fileName = "Progression", menuName = "Stats/New Progression", order = 0)]
    public class EnemyProgression : ScriptableObject
    {
        [SerializeField] EnemyProgressionClass[] enemyClasses;

        Dictionary<EnemyClass, Dictionary<EnemyStat, float[]>> lookupTable = null;

        public float GetStat(EnemyClass enemyClass, EnemyStat stat, int level)
        {
            BuildLookup();

            float[] levels = lookupTable[enemyClass][stat];

            if (levels.Length < level)
            {
                return 0;
            }

            return levels[level - 1];
        }

        private void BuildLookup()
        {
            if (lookupTable != null) return;

            lookupTable = new Dictionary<EnemyClass, Dictionary<EnemyStat, float[]>>();

            foreach (EnemyProgressionClass enemyProgressionClass in enemyClasses)
            {
                var statLookupTable = new Dictionary<EnemyStat, float[]>();
                foreach (EnemyProgressionStat progressionStat in enemyProgressionClass.stats)
                {
                    statLookupTable[progressionStat.stat] = progressionStat.levels;
                }
                lookupTable[enemyProgressionClass.characterClass] = statLookupTable;
            }
        }

        public int GetLevels(EnemyClass enemyClass, EnemyStat stat)
        {
            BuildLookup();

            float[] levels = lookupTable[enemyClass][stat];

            return levels.Length;
        }

        [System.Serializable]
        class EnemyProgressionClass
        {
            public EnemyClass characterClass;
            public EnemyProgressionStat[] stats;
        }

        [System.Serializable]
        public class EnemyProgressionStat
        {
            public EnemyStat stat;
            public float[] levels;
        }
    }
}
