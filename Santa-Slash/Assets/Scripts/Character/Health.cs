using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class Health : MonoBehaviour
    {
        protected int minimumHealth = 0;
        protected int maximumHealth = 2;
        [SerializeField] protected int currentHealth;
        protected bool isDead;
        [SerializeField] protected bool shouldTakeKnockback;

        protected bool TakeDamage(int damage)
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
