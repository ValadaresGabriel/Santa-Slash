using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Events;

namespace TranscendenceStudio.Character
{
    public class EnemyHealth : Health, IHittable
    {
        [SerializeField] EnemyManager enemyManager;
        [SerializeField] int weaponDurabilityDamage = 1;
        public UnityEvent<GameObject> TakeKnockback;

        private void Start()
        {
            if (enemyManager != null)
                currentHealth = enemyManager.enemy.maxHealth;
        }

        public void Hit(int damage, GameObject sender)
        {
            if (IsDead) return;
            if (sender.layer == gameObject.layer) return;

            if (sender == null)
            {
                Debug.LogError("Sender is NULL!");
                return;
            }

            if (TakeDamage(damage))
            {
                if (shouldTakeKnockback)
                {
                    TakeKnockback?.Invoke(sender);
                }

                if (currentHealth <= 0)
                {
                    IsDead = true;
                    Death?.Invoke();
                    enemyManager.CharacterAnimatorManager.ChangeCharacterAnimation(CharacterAnimation.Dead);
                }
                else
                {
                    enemyManager.CharacterAnimatorManager.ChangeCharacterAnimation(CharacterAnimation.Take_Damage);
                }

                return;
            }
            else
            {
                IsDead = true;
            }
        }

        // private void UpdateHealthBar()
        // {
        //     if (_targetHealthBar != null)
        //     {
        //         _targetHealthBar.UpdateBar(currentHealth, minimumHealth, maximumHealth, true);
        //     }
        // }

        public Vector3 TargetPosition()
        {
            return transform.position;
        }

        public int GetWeaponDurabilityDamage()
        {
            return weaponDurabilityDamage;
        }
    }
}
