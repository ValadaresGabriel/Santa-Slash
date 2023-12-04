using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.AI
{
    public class AITargetDetector : AIDetector
    {
        [SerializeField] float targetDetectionRange = 5f;
        [SerializeField] LayerMask obstacleLayerMask;
        [SerializeField] LayerMask playerLayerMask;
        [SerializeField] bool showGizmos = false;

        // For Gizmo
        private List<Transform> colliderTransforms;

        public override void Detect(AIData aiData)
        {
            Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, targetDetectionRange, playerLayerMask);

            if (playerCollider != null)
            {
                // Check if sees the player

                Vector2 direction = (playerCollider.transform.position - transform.position).normalized;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, targetDetectionRange, obstacleLayerMask);

                // Make sure that the collider we see is on the "Player" layer

                if (hit.collider != null && (playerLayerMask & (1 << hit.collider.gameObject.layer)) != 0)
                {
                    colliderTransforms = new List<Transform> { playerCollider.transform };
                }
                else
                {
                    colliderTransforms = null;
                }
            }
            else
            {
                colliderTransforms = null;
            }

            aiData.targets = colliderTransforms;
        }

        private void OnDrawGizmosSelected()
        {
            if (!showGizmos) return;

            Gizmos.DrawWireSphere(transform.position, targetDetectionRange);

            if (colliderTransforms == null) return;

            Gizmos.color = Color.magenta;

            foreach (Transform collider in colliderTransforms)
            {
                Gizmos.DrawSphere(collider.position, 0.3f);
            }
        }
    }
}
