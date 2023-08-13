using UnityEngine;

namespace Arena.EnemySpawning
{
    public class SpawnPoint : MonoBehaviour
    {
        bool isInRange;

        public bool IsInRange()
        {
            return isInRange;
        }

        public void CheckIfInRange(BoundsInt bounds)
        {
            if (transform.position.x < bounds.min.x ||
                transform.position.x > bounds.max.x ||
                transform.position.y < bounds.min.y ||
                transform.position.y > bounds.max.y)
            {
                isInRange = false;
            }
            else
            {
                isInRange = true;
            }
        }
    }
}