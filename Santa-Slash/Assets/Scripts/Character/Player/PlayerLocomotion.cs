using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class PlayerLocomotion : MonoBehaviour
    {
        [SerializeField] float movementSpeed = 6f;
        private Rigidbody2D rb;
        private CharacterAnimatorManager characterAnimatorManager;
        private Vector2 movementValue;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            characterAnimatorManager = GetComponent<CharacterAnimatorManager>();
        }

        private void Update()
        {
            movementValue = PlayerInputManager.Instance.MovementValue;

            SwapPlayer();
        }

        private void FixedUpdate()
        {
            if (PlayerInputManager.Instance == null) return;

            rb.velocity = movementSpeed * movementValue;

            HandleAnimation();
        }

        private void HandleAnimation()
        {
            if (movementValue == Vector2.zero)
            {
                characterAnimatorManager.ChangeCharacterAnimation(CharacterAnimation.Idle);
                return;
            }

            if (movementValue.x != 0)
            {
                characterAnimatorManager.ChangeCharacterAnimation(CharacterAnimation.Run);
            }
        }

        private void SwapPlayer()
        {
            Vector2 direction = (PlayerInputManager.Instance.GetMousePositionValue() - (Vector2)transform.position).normalized;

            float angle = direction.x < 0 ? 180f : 0f;
            float currentYAngle = transform.eulerAngles.y;

            if (Mathf.Abs(currentYAngle - angle) < 0.1f) return;

            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
}
