using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class CharacterLocomotion : MonoBehaviour
    {
        [SerializeField] protected float movementSpeed = 6f;
        [SerializeField] protected float speedMultiplier = 1f;
        protected Rigidbody2D rb;
        protected CharacterAnimatorManager characterAnimatorManager;
        public Vector2 MovementValue { get; set; }
        public Vector2 Direction { get; set; }

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            characterAnimatorManager = GetComponent<CharacterAnimatorManager>();
        }

        protected virtual void Start()
        {

        }

        protected virtual void Update()
        {

        }

        protected virtual void FixedUpdate()
        {
            rb.velocity = movementSpeed * speedMultiplier * MovementValue;

            HandleAnimation();
        }

        protected void HandleAnimation()
        {
            if (MovementValue == Vector2.zero)
            {
                characterAnimatorManager.ChangeCharacterAnimation(CharacterAnimation.Idle);
                return;
            }

            if (MovementValue.x != 0 || MovementValue.y != 0)
            {
                characterAnimatorManager.ChangeCharacterAnimation(CharacterAnimation.Run);
            }
        }

        protected void Swap()
        {
            float angle = Direction.x < 0 ? 180f : 0f;
            float currentYAngle = transform.eulerAngles.y;

            if (Mathf.Abs(currentYAngle - angle) < 0.1f) return;

            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        public void ApplyMovementSpeedMultiplier(float multiplier)
        {
            speedMultiplier = multiplier;
        }
    }
}
