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

            if (playerManager.characterWeaponManager.equippedWeapon.dealDamageVFX != null)
            {
                GameObject damageVFX = HitVFXManager.Instance.GetVFX();
                damageVFX.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
                damageVFX.transform.SetPositionAndRotation(hittable.TargetPosition(), Quaternion.identity);
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
