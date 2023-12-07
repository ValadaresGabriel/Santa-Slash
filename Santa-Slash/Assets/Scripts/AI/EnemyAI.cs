using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;
using UnityEngine.Events;

namespace TranscendenceStudio.AI
{
    public class EnemyAI : MonoBehaviour
    {
        [Header("AI Settings")]
        [SerializeField] List<AISteeringBehaviour> steeringBehaviours;
        [SerializeField] List<AIDetector> detectors;
        [SerializeField] AIData aiData;

        [Header("Delays")]
        [SerializeField] float detectionDelay = 0.05f;
        [SerializeField] float aiUpdateDelay = 0.06f;
        [SerializeField] float attackCooldown = 1f;

        [Header("Attack Distance")]
        [SerializeField] float attackRange = 0.5f;

        [Header("AI Inputs")]
        public UnityEvent<Vector2> OnMovementInput;
        public UnityEvent<Vector2> OnPointerInput;
        [SerializeField] Vector2 movementInput;
        [SerializeField] AIContextSolver movementDirectionSolver;

        private EnemyManager enemyManager;
        private bool following = false;

        private void Awake()
        {
            enemyManager = GetComponent<EnemyManager>();
        }

        private void OnEnable()
        {
            attackCooldown = enemyManager.enemy.attackCooldown;
            attackRange = enemyManager.enemy.attackRange;
        }

        private void Start()
        {
            InvokeRepeating(nameof(PerformDetection), 0, detectionDelay);

            aiData.currentTarget = PlayerManager.Instance.gameObject.transform;
        }

        private void PerformDetection()
        {
            foreach (AIDetector detector in detectors)
            {
                detector.Detect(aiData);
            }

            float[] danger = new float[8];
            float[] interest = new float[8];

            foreach (AISteeringBehaviour behaviour in steeringBehaviours)
            {
                (danger, interest) = behaviour.GetSteering(danger, interest, aiData);
            }
        }

        private void Update()
        {
            if (enemyManager.health.IsDead)
            {
                if (aiData.currentTarget != null)
                {
                    StopAllCoroutines();
                    aiData.currentTarget = null;
                }

                return;
            }

            // Enemy AI movement based on Target availability
            if (aiData.currentTarget != null)
            {
                // Looking at the Target
                OnPointerInput?.Invoke(aiData.currentTarget.position);

                if (!following)
                {
                    following = true;
                    StartCoroutine(ChaseAndAttack());
                }
            }
            else if (aiData.GetTargetsCount > 0)
            {
                // Target acquisition logic
                aiData.currentTarget = aiData.targets[0];
            }
            // Moving the Agent
            OnMovementInput?.Invoke(movementInput);
        }

        private IEnumerator ChaseAndAttack()
        {
            if (enemyManager.health.IsDead)
                yield break;

            if (aiData.currentTarget == null)
            {
                Debug.Log("Stopping");
                movementInput = Vector2.zero;
                following = false;
                yield return null;
            }
            else
            {
                float distance = Vector2.Distance(aiData.currentTarget.position, transform.position);

                // Attack Logic
                if (distance < attackRange)
                {
                    movementInput = Vector2.zero;
                    // OnAttackPressed?.Invoke();
                    yield return new WaitForSeconds(attackCooldown);
                    StartCoroutine(ChaseAndAttack());
                }
                else
                {
                    // Chase logic
                    movementInput = movementDirectionSolver.GetDirectionToMove(steeringBehaviours, aiData);
                    yield return new WaitForSeconds(aiUpdateDelay);
                    StartCoroutine(ChaseAndAttack());
                }
            }
        }
    }
}
