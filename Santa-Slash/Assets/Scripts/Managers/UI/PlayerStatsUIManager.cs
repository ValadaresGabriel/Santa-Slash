using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TranscendenceStudio.UI
{
    public class PlayerStatsUIManager : MonoBehaviour
    {
        [Header("Health")]
        [SerializeField] Slider healthSlider;

        [Header("Stamina")]
        [SerializeField] Slider staminaSlider;

        [Header("Weapon Durability")]
        [SerializeField] Slider weaponDurabilitySlider;

        public void SetMaxHealth(int value)
        {
            healthSlider.maxValue = value;
        }

        public void SetMaxStamina(int value)
        {
            staminaSlider.maxValue = value;
        }

        public void SetMaxWeaponDurability(int value)
        {
            weaponDurabilitySlider.maxValue = value;
        }

        public void UpdateHealthSlider(int value)
        {
            healthSlider.value = value;
        }

        public void UpdateStaminaSlider(int value)
        {
            staminaSlider.value = value;
        }

        public void UpdateWeaponDurabilitySlider(int value)
        {
            weaponDurabilitySlider.value = value;
        }
    }
}
