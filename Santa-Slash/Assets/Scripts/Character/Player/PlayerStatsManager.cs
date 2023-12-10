using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.UI;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class PlayerStatsManager : MonoBehaviour
    {
        [SerializeField] int health;
        [SerializeField] int stamina;

        private void Awake()
        {
            UIManager.Instance.playerUIManager.SetMaxHealth(health);
            UIManager.Instance.playerUIManager.SetMaxStamina(stamina);
        }

        public int Health
        {
            get => health;
            set
            {
                health = value;
                UIManager.Instance.playerUIManager.UpdateHealthBar(stamina);
            }
        }

        public int Stamina
        {
            get => stamina;
            set
            {
                stamina = value;
                UIManager.Instance.playerUIManager.UpdateStaminaBar(stamina);
            }
        }
    }
}
