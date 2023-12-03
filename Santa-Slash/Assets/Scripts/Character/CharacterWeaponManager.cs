using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using TranscendenceStudio.Items;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class CharacterWeaponManager : MonoBehaviour
    {
        [Header("Weapon")]
        [SerializeField] SpriteRenderer weaponSpriteRenderer;
        [SerializeField] Animator weaponAnimator;
        [SerializeField] Weapon equippedWeapon;

        [Header("Weapon Radius Origin")]
        [SerializeField] Transform weaponRadiusOrigin;

        private Vector3 originalScale;

        private void Awake()
        {
            originalScale = transform.localScale;
        }

        private void Update()
        {
            FlipWeapon();
        }

        public void EquipWeapon(Weapon weapon)
        {
            equippedWeapon = weapon;
            weaponSpriteRenderer.sprite = equippedWeapon.itemIcon;
            weaponAnimator.runtimeAnimatorController = weapon.animator;
        }

        public void DetedEnemyArea()
        {
            foreach (Collider2D hittableObjects in Physics2D.OverlapCircleAll(weaponRadiusOrigin.position, equippedWeapon.weaponAttackRadius))
            {
                if (TryGetComponent(out IHittable hittable))
                {

                }
            }
        }

        private void FlipWeapon()
        {
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
    }
}
