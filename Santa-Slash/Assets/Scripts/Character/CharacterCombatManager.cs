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
            PlayerInputManager.Instance.AttackEvent += PerformAttack;
        }

        private void PerformAttack()
        {
            // playerManager.characterAnimatorManager.ChangeCharacterAnimation(CharacterAnimation.Attack);
            playerManager.weaponAnimatorManager.Attack();
        }

        private void OnDestroy()
        {
            PlayerInputManager.Instance.AttackEvent -= PerformAttack;
        }
    }
}
