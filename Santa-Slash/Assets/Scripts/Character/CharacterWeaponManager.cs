using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using TranscendenceStudio.Items;
using TranscendenceStudio.UI;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class CharacterWeaponManager : MonoBehaviour
    {
        [SerializeField] PlayerManager playerManager;
        [SerializeField] GameObject agent;
        [SerializeField] LayerMask targetLayer;

        [Header("Weapon")]
        [SerializeField] SpriteRenderer weaponSpriteRenderer;
        [SerializeField] Animator weaponAnimator;
        public Weapon equippedWeapon;
        private int weaponDurability = 100;

        [Header("Attack Area")]
        [SerializeField] GameObject rangedWeaponTrajectoryArrow;
        public GameObject spellArea;

        public float WeaponAttackDelay { get; private set; }
        public float WeaponAbilityDelay { get; private set; }
        private Vector3 originalScale;

        private void Awake()
        {
            originalScale = transform.localScale;
        }

        private void Start()
        {
            EquipWeapon(equippedWeapon);
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
            SetSpellAreaPosition();
        }

        public void SetWeaponAttackDelay()
        {
            WeaponAttackDelay = equippedWeapon.attackDelay;
        }

        public void SetWeaponAbilityDelay()
        {
            WeaponAbilityDelay = equippedWeapon.abilityDelay;
        }

        public void EquipWeapon(Weapon weapon)
        {
            equippedWeapon = weapon;

            weaponAnimator.runtimeAnimatorController = weapon.animator;
            weaponSpriteRenderer.sprite = equippedWeapon.itemIcon;
            weaponDurability = weapon.weaponDurability;

            playerManager.playerFeedback.GetFeedbackOfType<MMF_MMSoundManagerSound>().RandomSfx = weapon.sfxs;

            SetupAttackArea(weapon);
        }

        private void SetupAttackArea(Weapon weapon)
        {
            if (weapon.weaponAttackType == WeaponAttackType.Ranged)
            {
                if (spellArea.activeInHierarchy)
                    spellArea.SetActive(false);

                rangedWeaponTrajectoryArrow.SetActive(true);
            }
            else if (weapon.weaponAttackType == WeaponAttackType.Magic)
            {
                if (rangedWeaponTrajectoryArrow.activeInHierarchy)
                    rangedWeaponTrajectoryArrow.SetActive(false);

                spellArea.SetActive(true);
            }
            else
            {
                if (rangedWeaponTrajectoryArrow.activeInHierarchy)
                    rangedWeaponTrajectoryArrow.SetActive(false);

                if (!spellArea.activeInHierarchy)
                    spellArea.SetActive(false);
            }
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

        private void SetSpellAreaPosition()
        {
            if (!spellArea.activeInHierarchy) return;

            spellArea.transform.SetPositionAndRotation(PlayerInputManager.Instance.GetMousePositionValue(), Quaternion.identity);
        }

        public int WeaponDurability
        {
            get => weaponDurability;
            set
            {
                weaponDurability = value;
                UIManager.Instance.playerUIManager.UpdateWeaponDurabilitySlider(weaponDurability);
            }
        }
    }
}
