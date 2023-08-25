using Arena.HeroStats;
using UnityEngine;

namespace Arena.HeroAttributes
{
    public class Experience : MonoBehaviour
    {
        float _experience = 0;
        float expGain = 0;

        private void Awake()
        {
            expGain = GetComponent<BaseStats>().GetStat(HeroStat.ExpGain);
        }

        public void AddExpPoints(int expValue)
        {
            float pointsToAdd = expValue + (expValue * expGain / 100);
            _experience += pointsToAdd;
        }
    }
}
