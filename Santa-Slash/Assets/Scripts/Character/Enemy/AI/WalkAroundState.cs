using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using TranscendenceStudio.Character;
using UnityEngine;

namespace TranscendenceStudio.AI
{
    public class WalkAroundState : EnemyState
    {
        private Vector3 targetPosition = Vector3.zero;
        private float tolerance = 0.2f;
        private float timeInTheSameTargetPosition = 0;

        public override void EnterState(EnemyManager enemyManager)
        {
            base.EnterState(enemyManager);

            timeInTheSameTargetPosition = 0;
        }

        public override void Update()
        {
            timeInTheSameTargetPosition += Time.deltaTime;
        }

        public override void FixedUpdate()
        {
            if (targetPosition == Vector3.zero)
            {
                // Generate a new target position that's not inside an obstacle
                Vector3 newTarget = GenerateValidTargetPosition();
                if (newTarget != Vector3.zero)
                {
                    targetPosition = newTarget;
                }
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

            if (timeInTheSameTargetPosition >= 2)
            {
                Debug.Log("Changed to Default Idle State -> timeInTheSameTargetPosition >= 2");
                enemy.EnemyAI.ChangeState(new DefaultIdleState());
                return;
            }

            if (Vector3.Distance(enemy.transform.position, targetPosition) <= tolerance)
            {
                enemy.EnemyAI.ChangeState(new DefaultIdleState());
                return;
            }
        }

        private Vector3 GenerateValidTargetPosition()
        {
            // Shuffle the directions list for randomness
            enemy.EnemyAI.directionsToWalk.MMShuffle();

            foreach (Vector2 direction in enemy.EnemyAI.directionsToWalk)
            {
                RaycastHit2D hit = Physics2D.Raycast(enemy.transform.position, direction, 3, enemy.EnemyAI.obstacleMask);

                if (hit.collider == null)
                {
                    return (Vector2)enemy.transform.position + direction;
                }
            }

            return Vector3.zero;
        }

        public override void ExitState()
        {
            enemy.EnemyAI.StartWalkAround();
            enemy.Animator.SetInteger("Velocity", 0);
        }
    }
}
