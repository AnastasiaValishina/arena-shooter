using Arena.HeroStats;
using UnityEngine;

namespace Arena.HeroAttributes
{
    public class Experience : MonoBehaviour
    {
        float expGain = 0;

        public float ExpPoints { get; private set; }

        private void Awake()
        {
            expGain = GetComponent<Stats>().GetExpGain();
        }

        public void AddExpPoints(int expValue)
        {
            float pointsToAdd = expValue + (expValue * expGain / 100);
            ExpPoints += pointsToAdd;
        }
    }
}
