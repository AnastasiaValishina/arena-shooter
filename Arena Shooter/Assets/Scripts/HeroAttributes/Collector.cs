using Arena.HeroStats;
using UnityEngine;

namespace Arena.HeroAttributes
{
    public class Collector : MonoBehaviour
    {
        float raduis;

        private void Awake()
        {
            raduis = GetComponent<HeroBaseStat>().GetStat(HeroStat.MagnetRadius);
            GetComponent<CircleCollider2D>().radius = raduis; 
        }
    }
}
