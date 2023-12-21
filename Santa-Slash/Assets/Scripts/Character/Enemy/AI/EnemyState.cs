using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;

namespace TranscendenceStudio.AI
{
    public abstract class EnemyState : IState
    {
        protected EnemyManager enemy;

        public virtual void EnterState(EnemyManager enemyManager)
        {
            enemy = enemyManager;
        }

        public virtual void Update()
        {
            if (enemy.EnemyHealth.IsDead)
            {
                enemy.EnemyAI.ChangeState(new DefaultIdleState());
                return;
            }
        }

        public virtual void FixedUpdate()
        {
            if (enemy.EnemyHealth.IsDead)
            {
                return;
            }
        }

        public abstract void ExitState();

        protected bool IsPlayerInRange()
        {
            RaycastHit2D hit = Physics2D.CircleCast(enemy.transform.position, enemy.enemy.chasePlayerArea, Vector2.down, 0, enemy.playerLayerMask);

            if (hit.collider != null)
            {
                return true;
            }

            return false;
        }
    }
}
