using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class EnemyLocomotion : CharacterLocomotion
    {
        protected override void Update()
        {
            Swap();
        }
    }
}
