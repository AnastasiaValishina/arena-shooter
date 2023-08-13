using UnityEngine;

namespace Arena.Collectables
{
    public class CollectablesSpawner : MonoBehaviour
    {
        [SerializeField] GameObject[] boostersToSpawn;
        [Range(0, 100)][SerializeField] int spawnChance = 30;

        bool isQuitting;

        private void SpawnBooster()
        {
            int randomInt = Random.Range(0, 100);
            if (randomInt < spawnChance)
            {
                GameObject randomBooster = boostersToSpawn[Random.Range(0, boostersToSpawn.Length)];
                Instantiate(randomBooster, transform.position, Quaternion.identity);
            }
        }

        private void OnDestroy()
        {
            if (!isQuitting)
            {
                SpawnBooster();
            }
        }
        void OnApplicationQuit()
        {
            isQuitting = true;
        }
    }
}
