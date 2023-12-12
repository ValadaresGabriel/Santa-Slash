using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using TranscendenceStudio.Items;
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
            playerManager.playerFeedback.GetFeedbackOfType<MMF_MMSoundManagerSound>().RandomSfx = weapon.sfxs;
            weaponDurability = weapon.weaponDurability;
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
