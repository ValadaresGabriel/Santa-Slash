using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class EnemyLocomotion : CharacterLocomotion
    {
        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Start()
        {
            base.Start();

            movementSpeed = (characterManager as EnemyManager).enemy.speed;
        }

        protected override void Update()
        {
            Swap();
        }
    }
}
