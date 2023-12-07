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
        [SerializeField] int damage = 1;
        [SerializeField] int weaponDurabilityDamage = 1;
        // protected MMHealthBar _targetHealthBar;
        public UnityEvent<GameObject> TakeKnockback;
        public UnityEvent Death;

        private void Awake()
        {
            // _targetHealthBar = GetComponent<MMHealthBar>();
        }

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
                // UpdateHealthBar();

                if (shouldTakeKnockback)
                {
                    TakeKnockback?.Invoke(sender);
                }

                if (currentHealth <= 0)
                {
                    IsDead = true;
                    Death?.Invoke();
                    enemyManager.characterAnimatorManager.ChangeCharacterAnimation(CharacterAnimation.Dead);
                }
                else
                {
                    enemyManager.characterAnimatorManager.ChangeCharacterAnimation(CharacterAnimation.Take_Damage);
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
