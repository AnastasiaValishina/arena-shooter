using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyBaseStats : MonoBehaviour
{
    [SerializeField] EnemyClass characterClass;
    [SerializeField] EnemyProgression progression = null;

    public float GetStat(EnemyStat stat)
    {
        var baseStat = GetBaseStat(stat); 
        return baseStat + (GetPercentageModifier(stat) * baseStat / 100);
    }

    private float GetBaseStat(EnemyStat stat)
    {
        return progression.GetStat(characterClass, stat);
    }

    private float GetPercentageModifier(EnemyStat stat)
    {
        float total = 0;
        foreach (IModifierProvider provider in FindObjectsOfType<Buffer>().OfType<IModifierProvider>())
        {
            foreach (float modifier in provider.GetPercentageModifiers(stat))
            {
                total += modifier;
            }
        }
        return total;
    }
}
