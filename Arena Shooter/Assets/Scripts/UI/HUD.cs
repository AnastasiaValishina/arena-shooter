using Arena.PlayerAttributes;
using TMPro;
using UnityEngine;

namespace Arena.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI hpText;
        PlayerHealth playerHealth;

        void Start()
        {
            playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        }

        void Update()
        {
            hpText.text = playerHealth.GetHealthPoints().ToString();
        }
    }
}
