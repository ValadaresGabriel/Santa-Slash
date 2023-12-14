using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace TranscendenceStudio.Items
{
    public enum WeaponType
    {
        Sword,
        Knife,
        Staff,
        Shield,
        Excalibur,
        Axe,
        Mass,
    }

    public enum WeaponAttackType
    {
        Melee,
        Magic,
        Ranged,
    }

    [CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
    public class Weapon : Item
    {
        [Header("Weapon Type")]
        public WeaponType weaponType;

        [Header("Weapon Attack Type")]
        public WeaponAttackType weaponAttackType;

        [Header("Animator")]
        public RuntimeAnimatorController animator;

        [Header("Weapon Settings")]
        public int weaponDamage = 1;
        public Vector2 weaponAttackArea;
        public float attackDelay = 0.5f;
        public float abilityDelay = 0.5f;
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
