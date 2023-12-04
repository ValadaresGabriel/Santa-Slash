using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Events;

namespace TranscendenceStudio.Character
{
    public class EnemyHealth : Health, IHittable
    {
        protected MMHealthBar _targetHealthBar;
        public UnityEvent<GameObject> TakeKnockback;
        public UnityEvent<GameObject> Death;

        private void Awake()
        {
            _targetHealthBar = GetComponent<MMHealthBar>();
            currentHealth = maximumHealth;
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
                UpdateHealthBar();

                if (shouldTakeKnockback)
                {
                    TakeKnockback?.Invoke(sender);
                }

                return;
            }
            else
            {
                IsDead = true;
            }

            Debug.Log("Is Dead");
        }

        private void UpdateHealthBar()
        {
            if (_targetHealthBar != null)
            {
                _targetHealthBar.UpdateBar(currentHealth, minimumHealth, maximumHealth, true);
            }
        }
    }
}
