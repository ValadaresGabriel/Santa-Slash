using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.AI
{
    public class AIObstacleAvoidanceBehaviour : AISteeringBehaviour
    {
        [SerializeField] float radius = 2f;
        [SerializeField] float agentColliderSize = 0.6f;
        [SerializeField] bool showGizmo = true;

        private float[] dangersResultTemp = null;

        public override (float[] danger, float[] interest) GetSteering(float[] danger, float[] interest, AIData aiData)
        {
            foreach (Collider2D obstacleCollider in aiData.obstacles)
            {
                Vector2 directionToObstacle = obstacleCollider.ClosestPoint(transform.position) - (Vector2)transform.position;
                float distanceToObstacle = directionToObstacle.magnitude;

                // Calculate weight based on the distance Enemy<--->Obstacle
                float weight = distanceToObstacle <= agentColliderSize ? 1 : (radius - distanceToObstacle) / radius;

                Vector2 directionToObstacleNormalized = directionToObstacle.normalized;

                // Add obstacle parameters to the danger array
                for (int i = 0; i < Directions.eightDirections.Count; i++)
                {
                    float result = Vector2.Dot(directionToObstacleNormalized, Directions.eightDirections[i]);

                    float valueToPutIn = result * weight;

                    // Override value only if it is higher than the current one stored in the danger array
                    if (valueToPutIn > danger[i])
                    {
                        danger[i] = valueToPutIn;
                    }
                }
            }

            dangersResultTemp = danger;
            return (danger, interest);
        }

        private void OnDrawGizmos()
        {
            if (!showGizmo) return;

            if (Application.isPlaying && dangersResultTemp != null)
            {
                if (dangersResultTemp != null)
                {
                    Gizmos.color = Color.red;

                    for (int i = 0; i < dangersResultTemp.Length; i++)
                    {
                        Gizmos.DrawRay(transform.position, Directions.eightDirections[i] * dangersResultTemp[i]);
                    }
                }
            }
            else
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawWireSphere(transform.position, radius);
            }
        }
    }

    public static class Directions
    {
        public static List<Vector2> eightDirections = new List<Vector2>{
            new Vector2(0, 1).normalized,
            new Vector2(1, 1).normalized,
            new Vector2(1, 0).normalized,
            new Vector2(1, -1).normalized,
            new Vector2(0, -1).normalized,
            new Vector2(-1, -1).normalized,
            new Vector2(-1, 0).normalized,
            new Vector2(-1, 1).normalized,
        };
    }
}