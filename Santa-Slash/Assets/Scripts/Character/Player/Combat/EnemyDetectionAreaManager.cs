using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;

public class EnemyDetectionAreaManager : MonoBehaviour
{
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float radius = 5;

    private void FixedUpdate()
    {
        Collider2D enemyDetection = Physics2D.OverlapCircle(transform.position, radius, enemyLayer);

        if (enemyDetection == null)
        {
            if (PlayerManager.Instance.IsInBattle)
            {
                PlayerManager.Instance.IsInBattle = false;
            }
            return;
        }

        if (!PlayerManager.Instance.IsInBattle)
        {
            PlayerManager.Instance.IsInBattle = true;
        }
    }
}
