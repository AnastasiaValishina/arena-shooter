using Arena.HeroStats;
using UnityEngine;

namespace Arena.HeroAttributes
{
    public class Collector : MonoBehaviour
    {
        float raduis;

        private void Awake()
        {
            raduis = GetComponent<Stats>().GetMagnetRadius();
            GetComponent<CircleCollider2D>().radius = raduis; 
        }
    }
}
