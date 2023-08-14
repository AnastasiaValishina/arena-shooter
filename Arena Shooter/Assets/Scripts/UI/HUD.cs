using Arena.PlayerAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arena.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI hpText;
        [SerializeField] TextMeshProUGUI jumpCooldownText;
        [SerializeField] Image jumpCooldownTint;

        PlayerHealth playerHealth;
        PlayerController playerController;

        void Start()
        {
            GameObject player = GameObject.FindWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
            playerController = player.GetComponent<PlayerController>();
            jumpCooldownText.gameObject.SetActive(false);
            jumpCooldownTint.fillAmount = 0.0f;
        }

        void Update()
        {
            hpText.text = playerHealth.GetHealthPoints().ToString();
            UpdateCooldown();
        }

        void UpdateCooldown()
        {
            if (playerController.IsCooldown)
            {
                if (!jumpCooldownText.gameObject.activeSelf)
                {
                    jumpCooldownText.gameObject.SetActive(true);
                }                    

                jumpCooldownText.text = Mathf.RoundToInt(playerController.JumpCooldownTimer).ToString();
                jumpCooldownTint.fillAmount = playerController.JumpCooldownTimer / playerController.JumpCooldownTime;
            }
            else
            {
                if (jumpCooldownText.gameObject.activeSelf)
                {
                    jumpCooldownText.gameObject.SetActive(false);
                }                    
            }
        }
    }
}
