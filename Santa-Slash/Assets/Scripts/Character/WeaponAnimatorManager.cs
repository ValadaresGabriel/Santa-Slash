using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class WeaponAnimatorManager : MonoBehaviour
    {
        [SerializeField] PlayerManager playerManager;
        private Animator animator;
        private CharacterWeaponManager characterWeaponManager;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            characterWeaponManager = GetComponentInParent<CharacterWeaponManager>();
        }

        public void Attack()
        {
            animator.SetTrigger("Attack");
        }

        public void SetIsAttackingToTrue()
        {
            playerManager.IsAttacking = true;
        }

        public void SetIsAttackingToFalse()
        {
            playerManager.IsAttacking = false;
        }
    }
}
