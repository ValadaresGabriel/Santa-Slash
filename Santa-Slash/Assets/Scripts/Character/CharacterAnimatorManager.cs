using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public enum CharacterAnimation
    {
        Idle,
        Run,
        Take_Damage,
        Dash,
        Dead,
    }

    public class CharacterAnimatorManager : MonoBehaviour
    {
        protected CharacterAnimation characterAnimation;
        public Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        protected readonly Dictionary<CharacterAnimation, string> animations = new()
        {
            { CharacterAnimation.Idle, "Idle" },
            { CharacterAnimation.Run, "Run" },
            { CharacterAnimation.Take_Damage, "Take_Damage" },
            { CharacterAnimation.Dash, "Dash" },
            { CharacterAnimation.Dead, "Dead" },
        };

        public virtual void ChangeCharacterAnimation(CharacterAnimation newAnimation)
        {
            if (newAnimation == characterAnimation || PlayerManager.Instance.IsAttacking) return;

            characterAnimation = newAnimation;

            animator.Play(animations[newAnimation]);
        }
    }
}
