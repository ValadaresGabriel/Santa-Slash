using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TranscendenceStudio.UI
{
    public class PlayerUIManager : MonoBehaviour
    {
        [Header("Health Settings")]
        [SerializeField] Slider healthSlider;

        [Header("Stamina Settings")]
        [SerializeField] Slider staminaSlider;
        [SerializeField] float delayToStartToRecoverStamina = 3f;
        [SerializeField] float timeToFullyRecoverStamina = 6f;

        private Coroutine staminaRecoveryCoroutine;

        private void Awake()
        {
            healthSlider.value = 10;
            staminaSlider.value = 10;
        }

        public void SetMaxHealth(int value)
        {
            healthSlider.maxValue = value;
        }

        public void SetMaxStamina(int value)
        {
            staminaSlider.maxValue = value;
        }

        public void UpdateHealthBar(int value)
        {
            healthSlider.value -= value;
        }

        public void UpdateStaminaBar(int value)
        {
            staminaSlider.value -= value;

            StopCoroutine(staminaRecoveryCoroutine);
            staminaRecoveryCoroutine = StartCoroutine(AttemptToRecoverStamina());
        }

        private IEnumerator AttemptToRecoverStamina()
        {
            yield return new WaitForSeconds(delayToStartToRecoverStamina);

            float currentTime = 0f;

            while (currentTime < timeToFullyRecoverStamina)
            {
                currentTime += Time.deltaTime;
                float fraction = currentTime / timeToFullyRecoverStamina;
                staminaSlider.value += fraction;
                yield return null;
            }
        }
    }
}
