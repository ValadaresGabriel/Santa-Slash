using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;

namespace TranscendenceStudio.AI
{
    public interface IState
    {
        void EnterState(EnemyManager enemyManager);

        void Update();

        void FixedUpdate();

        void ExitState();
    }
}
