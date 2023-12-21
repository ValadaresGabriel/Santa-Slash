using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class CharacterManager : MonoBehaviour
    {
        public CharacterAnimatorManager CharacterAnimatorManager { get; private set; }
        public CharacterLocomotion characterLocomotion;

        protected virtual void Awake()
        {
            CharacterAnimatorManager = GetComponent<CharacterAnimatorManager>();
            characterLocomotion = GetComponent<CharacterLocomotion>();
        }

        public bool isAttacking = false;

        public bool IsAttacking
        {
            get => isAttacking;
            set => isAttacking = value;
        }
    }
}
