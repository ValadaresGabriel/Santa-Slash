using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Items
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
    public class Weapon : Item
    {
        [Header("Animator")]
        public RuntimeAnimatorController animator;

        [Header("Weapon Settings")]
        public float weaponAttackRadius = 1;
        public float delay = 0.5f;
        public int weaponDamage = 1;
        public ParticleSystem weaponParticleSystem;
    }
}
