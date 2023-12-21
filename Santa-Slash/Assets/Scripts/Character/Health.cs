using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TranscendenceStudio.Character
{
    public class Health : MonoBehaviour
    {
        [SerializeField] protected int maximumHealth = 2;
        [SerializeField] protected int currentHealth;
        protected bool isDead;
        [SerializeField] protected bool shouldTakeKnockback;
        public UnityEvent Death;

        protected virtual void Awake()
        {

        }

        public bool TakeDamage(int damage)
        {
            if (currentHealth > 0)
            {
                currentHealth -= damage;
                return true;
            }

            return false;
        }

        public bool IsDead
        {
            get => isDead;
            set => isDead = value;
        }
    }
}
