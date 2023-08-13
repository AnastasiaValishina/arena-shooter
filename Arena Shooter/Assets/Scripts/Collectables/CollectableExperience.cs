using Arena.PlayerStats;
using UnityEngine;

namespace Arena.Collectables // �������� ����� ��������� � ������ Experience
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
