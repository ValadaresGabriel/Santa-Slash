using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TranscendenceStudio.AI
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] List<AISteeringBehaviour> steeringBehaviours;
        [SerializeField] List<AIDetector> detectors;
        [SerializeField] AIData aiData;

        [Header("Delays")]
        [SerializeField] float detectionDelay = 0.05f;
        [SerializeField] float aiUpdateDelay = 0.06f;
        [SerializeField] float attackDelay = 1f;

        [Header("Attack Distance")]
        [SerializeField] float attackDistance = 0.5f;

        [Header("AI Inputs")]
        public UnityEvent<Vector2> OnMovementInput;
        public UnityEvent<Vector2> OnPointerInput;
        [SerializeField] Vector2 movementInput;
        [SerializeField] AIContextSolver movementDirectionSolver;

        private bool following = false;

        private void Start()
        {
            InvokeRepeating(nameof(PerformDetection), 0, detectionDelay);
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
                if (distance < attackDistance)
                {
                    movementInput = Vector2.zero;
                    // OnAttackPressed?.Invoke();
                    yield return new WaitForSeconds(attackDelay);
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
