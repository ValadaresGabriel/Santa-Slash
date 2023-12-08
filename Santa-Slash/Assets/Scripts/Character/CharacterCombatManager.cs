using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class CharacterCombatManager : MonoBehaviour
    {
        private PlayerManager playerManager;

        private void Awake()
        {
            playerManager = GetComponent<PlayerManager>();
        }

        private void Start()
        {
            PlayerInputManager.Instance.AttackEvent += AttemptToPerformAttack;
            PlayerInputManager.Instance.AbilityEvent += AttemptToPerformAbility;
        }

        private void AttemptToPerformAttack()
        {
            if (playerManager.characterWeaponManager.WeaponAttackDelay > 0) return;

            playerManager.characterWeaponManager.SetWeaponAttackDelay();
            playerManager.weaponAnimatorManager.PerformAttack();
        }

        private void AttemptToPerformAbility()
        {
            if (playerManager.characterWeaponManager.WeaponAbilityDelay > 0) return;

            playerManager.characterWeaponManager.SetWeaponAbilityDelay();
            playerManager.weaponAnimatorManager.PerformAbility();
        }

        private void OnDestroy()
        {
            PlayerInputManager.Instance.AttackEvent -= AttemptToPerformAttack;
            PlayerInputManager.Instance.AbilityEvent -= AttemptToPerformAbility;
        }
    }
}
