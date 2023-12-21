using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;

namespace TranscendenceStudio.AI
{
    public class ChaseState : EnemyState
    {
        private Vector3 targetPosition = Vector3.zero;

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
            targetPosition = PlayerManager.Instance.transform.position;

            Vector3 direction = targetPosition - enemy.transform.position;
            direction.Normalize();

            enemy.Rb.MovePosition(enemy.transform.position + (enemy.enemy.speed * Time.deltaTime * direction));

            enemy.Animator.SetInteger("Velocity", 1);

            if (!IsPlayerInRange())
            {
                enemy.EnemyAI.ChangeState(new DefaultIdleState());
                return;
            }

            if (Vector3.Distance(enemy.transform.position, targetPosition) <= enemy.enemy.attackRange && enemy.EnemyAI.CanAttack)
            {
                enemy.EnemyAI.ChangeState(new AttackState());
            }
        }

        public override void ExitState()
        {
            enemy.Animator.SetInteger("Velocity", 0);
        }
    }
}
