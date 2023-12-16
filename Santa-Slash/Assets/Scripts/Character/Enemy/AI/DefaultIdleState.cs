using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;

namespace TranscendenceStudio.AI
{
    public class DefaultIdleState : EnemyState
    {
        public override void EnterState(EnemyManager enemyManager)
        {
            base.EnterState(enemyManager);
        }

        public override void Update()
        {
            //
        }

        public override void FixedUpdate()
        {
            if (Vector2.Distance(enemy.transform.position, PlayerManager.Instance.transform.position) <= enemy.enemy.attackRange)
            {
                Debug.Log("<color=green>Player is in attack range -> Enter AttackState</color>");
                return;
            }

            if (IsPlayerInRange())
            {
                Debug.Log("<color=green>Player is in chase range -> Enter ChaseState</color>");
                return;
            }

            if (enemy.EnemyAI.canWalkAround)
            {
                Debug.Log("<color=green>Player is not in range -> Enter WalkAroundState</color>");
                enemy.EnemyAI.ChangeState(new WalkAroundState());
            }
        }

        public override void ExitState()
        {
            //
        }
    }
}
