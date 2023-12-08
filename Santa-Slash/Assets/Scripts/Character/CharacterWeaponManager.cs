using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using TranscendenceStudio.Items;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

namespace TranscendenceStudio.Character
{
    public class CharacterWeaponManager : MonoBehaviour
    {
        [SerializeField] GameObject agent;
        [SerializeField] LayerMask targetLayer;

        [Header("Weapon")]
        [SerializeField] SpriteRenderer weaponSpriteRenderer;
        [SerializeField] Animator weaponAnimator;
        public Weapon equippedWeapon;
        private int weaponDurability = 100;

        [Header("Weapon Radius Origin")]
        [SerializeField] Transform weaponRadiusOrigin;


        public float WeaponAttackDelay { get; private set; }
        public float WeaponAbilityDelay { get; private set; }
        private Vector3 originalScale;

        private void Awake()
        {
            originalScale = transform.localScale;
        }

        private void Update()
        {
            if (WeaponAttackDelay > 0)
            {
                WeaponAttackDelay -= Time.deltaTime;
            }

            if (WeaponAbilityDelay > 0)
            {
                WeaponAbilityDelay -= Time.deltaTime;
            }

            FlipWeapon();
        }

        public void SetWeaponAttackDelay()
        {
            WeaponAttackDelay = equippedWeapon.attackDelay;
        }

        public void SetWeaponAbilityDelay()
        {
            WeaponAbilityDelay = equippedWeapon.attackDelay;
        }

        public void EquipWeapon(Weapon weapon)
        {
            weaponDurability = weapon.weaponDurability;
            equippedWeapon = weapon;
            weaponSpriteRenderer.sprite = equippedWeapon.itemIcon;
            weaponAnimator.runtimeAnimatorController = weapon.animator;
        }

        private void FlipWeapon()
        {
            if (PlayerManager.Instance.IsAttacking) return;

            Vector2 scale = transform.localScale;
            Vector2 direction = (PlayerInputManager.Instance.GetMousePositionValue() - (Vector2)transform.position).normalized;
            transform.right = direction;

            if (direction.x < 0)
            {
                scale.y = -originalScale.x;
            }
            else if (direction.x > 0)
            {
                scale.y = originalScale.x;
            }

            transform.localScale = scale;
        }

        public void SetWeaponDurability(int damageToWeaponDurability)
        {
            weaponDurability -= damageToWeaponDurability;
            // Atualizar na UI
        }
    }
}
