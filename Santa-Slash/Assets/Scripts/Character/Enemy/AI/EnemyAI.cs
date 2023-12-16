using System;
using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;

namespace TranscendenceStudio.AI
{
    public class EnemyAI : MonoBehaviour
    {
        [Space(5)]

        [Header("States Settings")]
        [Space(5)]
        [Header("Walk Around Settings")]
        public float walkAroundCooldown = 4;
        public bool canWalkAround = true;
        public EnemyState currentState;
        private EnemyManager enemyManager;
        private bool isChangingState = false;

        private void Awake()
        {
            enemyManager = GetComponent<EnemyManager>();
        }

        private void Start()
        {
            ChangeState(new DefaultIdleState());
        }

        public void ChangeState(EnemyState newState)
        {
            if (currentState == null)
            {
                Debug.Log($"<color=green>Starting {name}'s FSM</color>");

                currentState = newState;

                currentState.EnterState(enemyManager);

                return;
            }

            if (isChangingState) return;

            isChangingState = true;

            currentState.ExitState();

            currentState = newState;

            currentState.EnterState(enemyManager);

            isChangingState = false;
        }

        private void Update()
        {
            if (currentState == null)
            {
                Debug.LogError($"CurrentState is NULL: {name}");
                return;
            }

            if (isChangingState) return;

            currentState.Update();
        }

        private void FixedUpdate()
        {
            if (currentState == null)
            {
                Debug.LogError($"CurrentState is NULL: {name}");
                return;
            }

            if (isChangingState) return;

            currentState.FixedUpdate();
        }

        public void StartWalkAround()
        {
            StartCoroutine(SetWalkAroundCooldown());
        }

        private IEnumerator SetWalkAroundCooldown()
        {
            canWalkAround = false;

            yield return new WaitForSeconds(walkAroundCooldown);

            canWalkAround = true;
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, enemyManager.enemy.chasePlayerArea);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, enemyManager.enemy.attackRange);
        }
    }
}
