using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float healthPoints;

    PlayerController controller;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    public void TakeDamage(float damage)
    {
        healthPoints -= damage;

        controller.PlayHitAnimation();

        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
