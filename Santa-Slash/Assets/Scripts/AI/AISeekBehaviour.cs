using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TranscendenceStudio.AI
{
    public class AISeekBehaviour : AISteeringBehaviour
    {
        [SerializeField] float targetReachedThreshold = 0.5f;
        [SerializeField] bool showGizmos = true;

        private bool reachedLastTarget = true;

        // Gizmos Parameters
        private Vector2 targetPositionCached;
        private float[] interestsTemp;

        public override (float[] danger, float[] interest) GetSteering(float[] danger, float[] interest, AIData aiData)
        {
            // If we don`t have a target stop seeking
            // else set a new target

            if (reachedLastTarget)
            {
                if (aiData.targets == null || aiData.targets.Count <= 0)
                {
                    aiData.currentTarget = null;
                    return (danger, interest);
                }
                else
                {
                    reachedLastTarget = false;
                    aiData.currentTarget = aiData.targets.OrderBy(target => Vector2.Distance(target.position, transform.position)).First();
                }
            }

            if (aiData.currentTarget != null && aiData.targets != null && aiData.targets.Contains(aiData.currentTarget))
            {
                targetPositionCached = aiData.currentTarget.position;
            }

            if (Vector2.Distance(transform.position, targetPositionCached) < targetReachedThreshold)
            {
                reachedLastTarget = true;
                aiData.currentTarget = null;
                return (danger, interest);
            }

            // If we haven't yet reached the target do the main logic of finding the interest directions
            Vector2 directionToTarget = targetPositionCached - (Vector2)transform.position;

            for (int i = 0; i < interest.Length; i++)
            {
                float result = Vector2.Dot(directionToTarget.normalized, Directions.eightDirections[i]);

                // Accept only directions at the less than 90 degrees to the target direction
                if (result > 0)
                {
                    float valueToPutIn = result;
                    if (valueToPutIn > interest[i])
                    {
                        interest[i] = valueToPutIn;
                    }
                }
            }

            interestsTemp = interest;
            return (danger, interest);
        }

        private void OnDrawGizmosSelected()
        {
            if (!showGizmos) return;

            Gizmos.DrawSphere(targetPositionCached, 0.2f);

            if (Application.isPlaying && interestsTemp != null)
            {
                if (interestsTemp != null)
                {
                    Gizmos.color = Color.green;

                    for (int i = 0; i < interestsTemp.Length; i++)
                    {
                        Gizmos.DrawRay(transform.position, Directions.eightDirections[i] * interestsTemp[i]);
                    }
                }
            }

            if (!reachedLastTarget)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(targetPositionCached, 0.1f);
            }
        }
    }
}
