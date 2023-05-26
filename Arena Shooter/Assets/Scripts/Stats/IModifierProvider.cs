using System.Collections.Generic;

public interface IModifierProvider
{
     IEnumerable<float> GetAdditiveModifiers(EnemyStat stat);
     IEnumerable<float> GetPercentageModifiers(EnemyStat stat);
}
