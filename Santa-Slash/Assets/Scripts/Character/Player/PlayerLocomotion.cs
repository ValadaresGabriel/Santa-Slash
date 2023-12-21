using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class PlayerLocomotion : CharacterLocomotion
    {
        private PlayerManager playerManager;

        protected override void Awake()
        {
            base.Awake();
            playerManager = GetComponent<PlayerManager>();
        }

        protected override void Update()
        {
            if (playerManager.PlayerHealth.IsDead)
            {
                rb.velocity = Vector2.zero;
                return;
            }

            if (playerManager.IsInteracting)
            {
                Debug.Log("<color=#4287f5>The player is interacting, cannot move</color>");
                return;
            }

            MovementValue = PlayerInputManager.Instance.MovementValue;

            Direction = (PlayerInputManager.Instance.GetMousePositionValue() - (Vector2)transform.position).normalized;

            Swap();
        }
    }
}
