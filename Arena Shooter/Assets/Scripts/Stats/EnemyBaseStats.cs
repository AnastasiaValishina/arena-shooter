using System.Linq;
using UnityEngine;

public class EnemyBaseStats : MonoBehaviour
{
    [Range(1, 99)]
    [SerializeField] int startingLevel = 1;
    [SerializeField] EnemyClass characterClass;
    [SerializeField] EnemyProgression progression = null;

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
        set
        {

        }
    }

    public float GetStat(EnemyStat stat)
    {
        var baseStat = GetBaseStat(stat); 
        return baseStat + (GetPercentageModifier(stat) * baseStat / 100);
    }

    private float GetBaseStat(EnemyStat stat)
    {
        return progression.GetStat(characterClass, stat, CurrentLevel);
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
