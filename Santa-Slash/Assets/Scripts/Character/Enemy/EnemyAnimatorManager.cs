using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class EnemyAnimatorManager : CharacterAnimatorManager
    {
        public bool IsInteracting { get; set; }

        public override void ChangeCharacterAnimation(CharacterAnimation newAnimation)
        {
            if (newAnimation == characterAnimation || IsInteracting) return;

            characterAnimation = newAnimation;

            if (newAnimation == CharacterAnimation.Take_Damage || newAnimation == CharacterAnimation.Dead)
            {
                IsInteracting = true;
                animator.SetTrigger(animations[newAnimation]);
                return;
            }

            animator.Play(animations[newAnimation]);
        }

        public void SetInteractToFalse()
        {
            IsInteracting = false;
        }
    }
}
