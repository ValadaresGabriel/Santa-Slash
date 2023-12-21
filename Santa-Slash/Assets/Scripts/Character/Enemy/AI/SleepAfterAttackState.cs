using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;

namespace TranscendenceStudio.AI
{
    public class SleepAfterAttackState : EnemyState
    {
        private float currentTime = 0;

        public override void EnterState(EnemyManager enemyManager)
        {
            base.EnterState(enemyManager);

            enemy.Animator.SetInteger("Velocity", 0);
        }

        public override void Update()
        {
            currentTime += Time.deltaTime;

            if (currentTime > enemy.enemy.sleepAfterAttackTime)
            {
                enemy.EnemyAI.ChangeState(new DefaultIdleState());
            }
        }

        public override void FixedUpdate()
        {
        }

        public override void ExitState()
        {

        }
    }
}
