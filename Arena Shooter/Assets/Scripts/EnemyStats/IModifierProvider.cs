using System.Collections.Generic;

namespace Arena.EnemyStats
{
    public interface IModifierProvider
    {
        IEnumerable<float> GetAdditiveModifiers(EnemyStat stat);
        IEnumerable<float> GetPercentageModifiers(EnemyStat stat);
    }
}