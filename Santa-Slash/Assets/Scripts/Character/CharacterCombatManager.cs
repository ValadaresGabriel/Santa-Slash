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
        }

        private void AttemptToPerformAttack()
        {
            if (playerManager.characterWeaponManager.WeaponAttackDelay > 0) return;

            playerManager.characterWeaponManager.SetWeaponAttackDelay();
            playerManager.weaponAnimatorManager.Attack();
        }

        private void OnDestroy()
        {
            PlayerInputManager.Instance.AttackEvent -= AttemptToPerformAttack;
        }
    }
}
