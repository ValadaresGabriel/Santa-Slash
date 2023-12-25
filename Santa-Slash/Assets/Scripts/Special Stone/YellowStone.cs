using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.SpecialStone
{
    public class YellowStone : SpecialStone
    {
        [SerializeField] LayerMask enemyLayer;
        [SerializeField] float size = 5;
        [SerializeField] float coinAmmountModifier = 0.5f;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyDropManager>().dropQuantityModifier += coinAmmountModifier;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.transform.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyDropManager>().dropQuantityModifier -= coinAmmountModifier;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, size);
        }
    }
}
