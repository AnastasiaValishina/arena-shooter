using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float healthPoints;

    public void DealDamage(int damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
