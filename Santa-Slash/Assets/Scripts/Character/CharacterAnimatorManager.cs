using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public enum CharacterAnimation
    {
        Idle,
        Run,
        Attack,
        Dash,
        Dead,
    }

    public class CharacterAnimatorManager : MonoBehaviour
    {
        private CharacterAnimation characterAnimation;
        [SerializeField] Animator characterAnimator;

        private readonly Dictionary<CharacterAnimation, string> animations = new()
        {
            { CharacterAnimation.Idle, "Idle" },
            { CharacterAnimation.Run, "Run" },
            { CharacterAnimation.Attack, "Attack" },
            { CharacterAnimation.Dash, "Dash" },
            { CharacterAnimation.Dead, "Dead" },
        };

        public void ChangeCharacterAnimation(CharacterAnimation newAnimation)
        {
            if (newAnimation == characterAnimation || PlayerManager.Instance.IsAttacking) return;

            characterAnimation = newAnimation;

            Debug.Log(newAnimation);
            characterAnimator.Play(animations[newAnimation]);
        }
    }
}
