using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.AI
{
    public class AIObstacleDetector : AIDetector
    {
        [SerializeField] float detectionRadius = 2f;
        [SerializeField] LayerMask layerMask;
        [SerializeField] bool showGizmos = true;

        private Collider2D[] colliders;

        public override void Detect(AIData aiData)
        {
            colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, layerMask);
            aiData.obstacles = colliders;
        }

        private void OnDrawGizmos()
        {
            if (!showGizmos) return;

            if (Application.isPlaying && colliders != null)
            {
                Gizmos.color = Color.red;

                foreach (Collider2D obstacleCollider in colliders)
                {
                    Gizmos.DrawSphere(obstacleCollider.transform.position, 0.2f);
                }
            }
        }
    }
}