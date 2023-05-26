using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Progression", menuName = "Stats/New Progression", order = 0)]
public class EnemyProgression : ScriptableObject
{
    [SerializeField] EnemyProgressionClass[] enemyClasses;

    Dictionary<EnemyClass, Dictionary<EnemyStat, int>> lookupTable = null;

    public float GetStat(EnemyClass enemyClass, EnemyStat stat)
    {
        BuildLookup();

        return lookupTable[enemyClass][stat];
    }

    private void BuildLookup()
    {
        if (lookupTable != null) return;

        lookupTable = new Dictionary<EnemyClass, Dictionary<EnemyStat, int>>();

        foreach (EnemyProgressionClass enemyProgressionClass in enemyClasses)
        {
            var statLookupTable = new Dictionary<EnemyStat, int>();
            foreach (EnemyProgressionStat progressionStat in enemyProgressionClass.stats)
            {
                statLookupTable[progressionStat.stat] = progressionStat.value;
            }
            lookupTable[enemyProgressionClass.characterClass] = statLookupTable;
        }
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
        public int value;
        //public float[] levels;
    }
}
