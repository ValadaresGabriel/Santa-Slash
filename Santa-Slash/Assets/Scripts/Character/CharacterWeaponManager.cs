using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using TranscendenceStudio.Items;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class CharacterWeaponManager : MonoBehaviour
    {
        [SerializeField] GameObject agent;
        [SerializeField] LayerMask targetLayer;

        [Header("Weapon")]
        [SerializeField] SpriteRenderer weaponSpriteRenderer;
        [SerializeField] Animator weaponAnimator;
        [SerializeField] Weapon equippedWeapon;

        [Header("Weapon Radius Origin")]
        [SerializeField] Transform weaponRadiusOrigin;

        public float WeaponAttackDelay { get; private set; }
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

            FlipWeapon();
        }

        public void SetWeaponAttackDelay()
        {
            WeaponAttackDelay = equippedWeapon.delay;
        }

        public void EquipWeapon(Weapon weapon)
        {
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

        public void DetectEnemyArea()
        {
            foreach (Collider2D hittableObjects in Physics2D.OverlapCircleAll(weaponRadiusOrigin.position, equippedWeapon.weaponAttackRadius, targetLayer))
            {
                if (hittableObjects.TryGetComponent(out IHittable hittable))
                {
                    Debug.Log("Has hit something Hittable!");
                    hittable.Hit(equippedWeapon.weaponDamage, agent);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(weaponRadiusOrigin.position, equippedWeapon.weaponAttackRadius);
        }
    }
}
