using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.UI;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class PlayerStatsManager : MonoBehaviour
    {
        [Header("Stamina Settings")]
        [SerializeField] int maxStamina;
        private int stamina;
        [SerializeField] float delayToStartToRecoverStamina = 3f;
        private bool isRecoveringStamina = false;
        private Coroutine staminaRecoveryCoroutine;

        private void Start()
        {
            Stamina = maxStamina;

            UIManager.Instance.playerUIManager.SetMaxStamina(maxStamina);
        }

        public int Stamina
        {
            get => stamina;
            set
            {
                stamina = value;
                UIManager.Instance.playerUIManager.UpdateStaminaSlider(stamina);

                if (isRecoveringStamina)
                {
                    StopCoroutine(staminaRecoveryCoroutine);
                }

                staminaRecoveryCoroutine = StartCoroutine(AttemptToRecoverStamina());
            }
        }

        private IEnumerator AttemptToRecoverStamina()
        {
            isRecoveringStamina = true;

            yield return new WaitForSeconds(delayToStartToRecoverStamina);

            float currentTime = 0f;

            while (Stamina < maxStamina)
            {
                currentTime += Time.deltaTime;

                int staminaToAdd = Mathf.FloorToInt(currentTime);
                if (staminaToAdd > 0)
                {
                    stamina += staminaToAdd;
                    UIManager.Instance.playerUIManager.UpdateStaminaSlider(stamina);
                    currentTime = 0;
                }

                yield return null;
            }

            isRecoveringStamina = false;
        }
    }
}
