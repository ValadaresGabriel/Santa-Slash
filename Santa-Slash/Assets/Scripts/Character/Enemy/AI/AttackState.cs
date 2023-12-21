using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;

namespace TranscendenceStudio.AI
{
    public class AttackState : EnemyState
    {
        public override void EnterState(EnemyManager enemyManager)
        {
            base.EnterState(enemyManager);

            enemyManager.EnemyAI.StartAttack();
        }

        public override void Update()
        {
            //
        }

        public override void FixedUpdate()
        {

            enemy.EnemyAI.ChangeState(new SleepAfterAttackState());
        }

        public override void ExitState()
        {
            enemy.Animator.SetInteger("Velocity", 0);
        }
    }
}
