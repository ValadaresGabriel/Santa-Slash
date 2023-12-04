using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.AI
{
    public class AIContextSolver : MonoBehaviour
    {
        [SerializeField] bool showGizmos = true;

        // Gizmo Parameters
        private float[] interesetGizmo = new float[0];
        Vector2 resultDirection = Vector2.zero;
        private float rayLength = 1;

        private void Start()
        {
            interesetGizmo = new float[8];
        }

        public Vector2 GetDirectionToMove(List<AISteeringBehaviour> behaviours, AIData aiData)
        {
            float[] danger = new float[8];
            float[] interest = new float[8];

            // Loop through each behaviour
            foreach (AISteeringBehaviour behaviour in behaviours)
            {
                (danger, interest) = behaviour.GetSteering(danger, interest, aiData);
            }

            // Subtract danger values from interest array
            for (int i = 0; i < 8; i++)
            {
                interest[i] = Mathf.Clamp01(interest[i] - danger[i]);
            }

            interesetGizmo = interest;

            // Get the average direction
            Vector2 outputDirection = Vector2.zero;

            for (int i = 0; i < 8; i++)
            {
                outputDirection += Directions.eightDirections[i] * interest[i];
            }
            outputDirection.Normalize();

            resultDirection = outputDirection;

            // Return the selected movement direction
            return resultDirection;
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying && showGizmos)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawRay(transform.position, resultDirection * rayLength);
            }
        }
    }
}
