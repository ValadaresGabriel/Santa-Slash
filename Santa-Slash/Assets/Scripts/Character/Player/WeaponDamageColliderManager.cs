using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class WeaponDamageColliderManager : MonoBehaviour
    {
        private PlayerManager playerManager;
        private List<IHittable> hittables = new();

        [Header("Collider")]
        [SerializeField] Collider2D damageCollider;

        private GameObject damageVFXInstance;

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

        private void DamageTarget(IHittable hittable)
        {
            if (hittables.Contains(hittable)) return;

            hittables.Add(hittable);

            // RE-DO
            if (playerManager.characterWeaponManager.equippedWeapon.dealDamageVFX != null)
            {
                if (damageVFXInstance == null)
                {
                    damageVFXInstance = Instantiate(playerManager.characterWeaponManager.equippedWeapon.dealDamageVFX, hittable.TargetPosition(), Quaternion.identity);
                }
            }

            playerManager.playerFeedback.PlayFeedbacks();

            hittable.Hit(playerManager.characterWeaponManager.equippedWeapon.weaponDamage, playerManager.gameObject);
        }

        public virtual void EnableDamageCollider()
        {
            damageCollider.enabled = true;
        }

        public virtual void DisableDamageCollider()
        {
            damageCollider.enabled = false;
            hittables.Clear();
        }
    }
}
