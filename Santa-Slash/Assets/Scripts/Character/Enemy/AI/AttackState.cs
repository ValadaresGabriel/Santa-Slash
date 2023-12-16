using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;

namespace TranscendenceStudio.AI
{
    public class AttackState : EnemyState
    {
        private Vector3 targetPosition = Vector3.zero;

        public override void EnterState(EnemyManager enemyManager)
        {
            base.EnterState(enemyManager);

            targetPosition = PlayerManager.Instance.transform.position;
        }

        public override void Update()
        {
            //
        }

        public override void FixedUpdate()
        {
            enemy.Rb.MovePosition(2 * enemy.enemy.speed * targetPosition);

            enemy.Animator.SetInteger("Velocity", 1);

            if (Vector3.Distance(enemy.transform.position, targetPosition) <= enemy.enemy.attackRange)
            {
                enemy.EnemyAI.ChangeState(new DefaultIdleState());
            }
        }

        public override void ExitState()
        {
            enemy.Animator.SetInteger("Velocity", 1);
        }
    }
}
