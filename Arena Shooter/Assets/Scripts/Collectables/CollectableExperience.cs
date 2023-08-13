using Arena.PlayerStats;
using UnityEngine;

namespace Arena.Collectables // возможно стоит перенести к классу Experience
{
    public class CollectableExperience : MonoBehaviour
    {
        [SerializeField] int expValue;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag != "Player") { return; }
            FindObjectOfType<Experience>().AddExpPoints(expValue);
            Destroy(gameObject);
        }
    }
}
