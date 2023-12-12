using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace TranscendenceStudio.Items
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
    public class Weapon : Item
    {
        [Header("Animator")]
        public RuntimeAnimatorController animator;

        [Header("Weapon Settings")]
        public bool isRangedWeapon = false;
        public float weaponAttackRadius = 1;
        public float attackDelay = 0.5f;
        public float abilityDelay = 0.5f;
        public int weaponDamage = 1;
        public int weaponDurability = 100;
        public float knockbackStrength = 10;

        [Header("Stamina Cost")]
        public int staminaCost = 1;

        [Header("Weapon SFXs")]
        public AudioClip[] sfxs;

        [Header("Damage VFX")]
        public GameObject dealDamageVFX;
    }
}
