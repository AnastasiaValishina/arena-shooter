using UnityEngine;

public class CleanUpBooster : MonoBehaviour
{
    [SerializeField] float lifeTime = 5;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
            Destroy(gameObject);
        }
    }
}
