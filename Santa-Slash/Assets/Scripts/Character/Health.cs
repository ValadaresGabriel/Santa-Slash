using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class Health : MonoBehaviour, IHittable
    {
        private int maxHealth = 2;
        private int currentHealth;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        public void Hit()
        {
            //
        }
    }
}
