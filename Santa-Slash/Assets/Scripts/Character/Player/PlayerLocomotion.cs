using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class PlayerLocomotion : CharacterLocomotion
    {
        protected override void Update()
        {
            MovementValue = PlayerInputManager.Instance.MovementValue;

            Direction = (PlayerInputManager.Instance.GetMousePositionValue() - (Vector2)transform.position).normalized;

            Swap();
        }
    }
}
