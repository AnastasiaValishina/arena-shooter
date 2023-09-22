using Arena.HeroAttributes;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arena.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI hpText;
        [SerializeField] TextMeshProUGUI expText;
        [SerializeField] TextMeshProUGUI JumpsLeftText;
        [SerializeField] TextMeshProUGUI jumpCooldownText;
        [SerializeField] Image jumpCooldownTint;

        Health playerHealth;
        PlayerController playerController;
        Experience experience;

        void Start()
        {
            GameObject player = GameObject.FindWithTag("Player");
            playerHealth = player.GetComponent<Health>();
            playerController = player.GetComponent<PlayerController>();
            experience = player.GetComponent<Experience>();
            jumpCooldownText.gameObject.SetActive(false);
            jumpCooldownTint.fillAmount = 0.0f;
        }

        void Update()
        {
            hpText.text = Math.Truncate(playerHealth.HealthPoints).ToString();
            expText.text = Math.Truncate(experience.ExpPoints).ToString();
            JumpsLeftText.text = playerController.JumpsLeft.ToString();
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
