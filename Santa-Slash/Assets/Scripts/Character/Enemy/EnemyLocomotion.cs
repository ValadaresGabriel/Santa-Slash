using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class EnemyLocomotion : CharacterLocomotion
    {
        private EnemyManager enemyManager;

        protected override void Awake()
        {
            base.Awake();
            enemyManager = GetComponent<EnemyManager>();
        }

        protected override void Start()
        {
            base.Start();

            movementSpeed = enemyManager.enemy.speed;
        }

        protected override void Update()
        {
            if (enemyManager.EnemyHealth.IsDead)
            {
                rb.velocity = Vector2.zero;
                return;
            }

            Direction = (Direction - (Vector2)transform.position).normalized;
            Swap();
        }
    }
}
