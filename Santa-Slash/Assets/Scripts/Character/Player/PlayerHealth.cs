using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.UI;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class PlayerHealth : Health, IHittable
    {
        protected override void Awake()
        {
            currentHealth = maximumHealth;
        }

        private void Start()
        {
            UIManager.Instance.playerUIManager.playerStatsUIManager.SetMaxHealth(maximumHealth);
        }

        public int GetWeaponDurabilityDamage()
        {
            return 0;
        }

        public void Hit(int damage, GameObject sender)
        {
            if (TakeDamage(damage))
            {
                UIManager.Instance.playerUIManager.playerStatsUIManager.UpdateHealthSlider(currentHealth);

                if (currentHealth <= 0)
                {
                    IsDead = true;
                    Death?.Invoke();
                    PlayerManager.Instance.CharacterAnimatorManager.ChangeCharacterAnimation(CharacterAnimation.Dead);
                }
                else
                {
                    PlayerManager.Instance.takeDamageFeedback.PlayFeedbacks();
                    PlayerManager.Instance.CharacterAnimatorManager.animator.SetTrigger("Take_Damage");
                    // PlayerManager.Instance.characterAnimatorManager.ChangeCharacterAnimation(CharacterAnimation.Take_Damage);
                }

                return;
            }
        }

        public Vector3 TargetPosition()
        {
            return transform.position;
        }
    }
}
