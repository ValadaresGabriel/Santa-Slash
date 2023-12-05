using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class CharacterManager : MonoBehaviour
    {
        public CharacterAnimatorManager characterAnimatorManager { get; private set; }
        public Health health;

        protected virtual void Awake()
        {
            characterAnimatorManager = GetComponent<CharacterAnimatorManager>();
        }

        public bool isAttacking = false;

        public bool IsAttacking
        {
            get => isAttacking;
            set => isAttacking = value;
        }
    }
}
