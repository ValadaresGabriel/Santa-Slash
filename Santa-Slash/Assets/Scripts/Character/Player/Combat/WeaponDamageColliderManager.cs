using System;
using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.VFX;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class WeaponDamageColliderManager : MonoBehaviour
    {
        private PlayerManager playerManager;
        private List<IHittable> hittables = new();

        [Header("Weapon Attack Collider")]
        [SerializeField] protected Collider2D weaponDamageCollider;

        private void Start()
        {
            playerManager = PlayerManager.Instance;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IHittable hittable))
            {
                DamageTarget(hittable);
            }
        }

        protected virtual void DamageTarget(IHittable hittable)
        {
            if (hittables.Contains(hittable)) return;

            hittables.Add(hittable);

            if (playerManager.characterWeaponManager.equippedWeapon.dealDamageVFX != null)
            {
                GameObject damageVFX = HitVFXManager.Instance.GetObject();
                damageVFX.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
                damageVFX.transform.SetPositionAndRotation(hittable.TargetPosition(), Quaternion.identity);
            }

            playerManager.dealDamageFeedback.PlayFeedbacks();

            hittable.Hit(playerManager.characterWeaponManager.equippedWeapon.weaponDamage, playerManager.gameObject);
            playerManager.characterWeaponManager.WeaponDurability -= hittable.GetWeaponDurabilityDamage();
        }

        public virtual void EnableDamageCollider()
        {
            weaponDamageCollider.enabled = true;
        }

        public virtual void DisableDamageCollider()
        {
            weaponDamageCollider.enabled = false;
            hittables.Clear();
        }
    }
}
