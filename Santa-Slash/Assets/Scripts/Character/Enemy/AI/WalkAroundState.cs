using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;

namespace TranscendenceStudio.AI
{
    public class WalkAroundState : EnemyState
    {
        private Vector3 targetPosition = Vector3.zero;
        private float tolerance = 0.2f;
        private float currentVelocity;

        public override void EnterState(EnemyManager enemyManager)
        {
            base.EnterState(enemyManager);

            enemy.EnemyAI.StartWalkAround();
        }

        public override void Update()
        {
            //
        }

        public override void FixedUpdate()
        {
            if (targetPosition == Vector3.zero)
            {
                float xMultiplier = Random.Range(-1, 1);
                float yMultiplier = Random.Range(-1, 1);

                float x = Random.Range(1, 3) * xMultiplier;
                float y = Random.Range(1, 3) * yMultiplier;

                targetPosition = enemy.transform.position + new Vector3(x, y, 0);
            }

            Vector3 direction = targetPosition - enemy.transform.position;
            direction.Normalize();

            enemy.Rb.MovePosition(enemy.transform.position + (enemy.enemy.speed * Time.deltaTime * direction));

            enemy.Animator.SetInteger("Velocity", 1);

            if (IsPlayerInRange())
            {
                enemy.EnemyAI.ChangeState(new ChaseState());
                return;
            }

            if (Vector3.Distance(enemy.transform.position, targetPosition) <= tolerance)
            {
                enemy.EnemyAI.ChangeState(new DefaultIdleState());
            }
        }

        public override void ExitState()
        {
            enemy.Animator.SetInteger("Velocity", 0);
        }
    }
}
