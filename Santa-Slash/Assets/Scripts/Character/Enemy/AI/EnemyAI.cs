using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;

namespace TranscendenceStudio.AI
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] EnemyManager enemyManager;
        public EnemyState currentState;
        private bool isChangingState = false;

        [Space(5)]
        [Header("---- States Settings ----")]
        [Space(5)]
        [Header("Walk Around")]
        public LayerMask obstacleMask;
        public List<Vector2> directionsToWalk = new();
        public float walkAroundCooldown = 4;
        public float radius = 2f;
        public float agentColliderSize = 0.6f;
        [SerializeField] bool canWalkAround = true;

        [Header("Attack")]
        [SerializeField] bool canAttack = true;

        private void Awake()
        {
            directionsToWalk.Add(Vector2.up);
            directionsToWalk.Add(Vector2.up + new Vector2(1f, 0));
            directionsToWalk.Add(Vector2.up + new Vector2(-1f, 0));

            directionsToWalk.Add(Vector2.down);
            directionsToWalk.Add(Vector2.down + new Vector2(-1f, 0));
            directionsToWalk.Add(Vector2.down + new Vector2(1f, 0));

            directionsToWalk.Add(Vector2.right);

            directionsToWalk.Add(Vector2.left);
        }

        private void Start()
        {
            ChangeState(new DefaultIdleState());
        }

        public void ChangeState(EnemyState newState)
        {
            if (currentState == null)
            {
                // Debug.Log($"<color=green>Starting {name}'s FSM</color>");

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

        // Walk Around State
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

        // Attack State
        public void StartAttack()
        {
            if (!canAttack)
            {
                Debug.Log("<color=yellow>Cannot attack player -> attack is in cooldown</color>");
                return;
            }

            StartCoroutine(SetAttackCooldown());
        }

        private IEnumerator SetAttackCooldown()
        {
            canAttack = false;

            // Deal damage 
            PlayerManager.Instance.PlayerHealth.Hit(enemyManager.enemy.damage, gameObject);

            enemyManager.KnockbackManager.PlayFeedback(PlayerManager.Instance.gameObject);

            yield return new WaitForSeconds(enemyManager.enemy.attackCooldown);

            canAttack = true;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, enemyManager.enemy.chasePlayerArea);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, enemyManager.enemy.attackRange);
        }

        public bool CanAttack
        {
            get => canAttack;
        }

        public bool CanWalkAround
        {
            get => canWalkAround;
        }
    }
}
