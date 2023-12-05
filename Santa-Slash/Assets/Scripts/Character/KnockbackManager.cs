using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.AI;
using TranscendenceStudio.Character;
using UnityEngine;
using UnityEngine.Events;

namespace TranscendenceStudio
{
    public class KnockbackManager : MonoBehaviour
    {
        private Rigidbody2D rb;
        [SerializeField] float strength = 10;
        [SerializeField] float delay = 0.2f;
        private EnemyManager enemyManager;

        private void Awake()
        {
            enemyManager = GetComponent<EnemyManager>();
            rb = GetComponent<Rigidbody2D>();
        }

        public void PlayFeedback(GameObject sender)
        {
            StopAllCoroutines();
            enemyManager.enemyLocomotion.enabled = false;

            Vector2 direction = (transform.position - sender.transform.position).normalized;
            rb.AddForce(direction * strength, ForceMode2D.Impulse);
            StartCoroutine(TimeToStopKnockback());
        }

        public IEnumerator TimeToStopKnockback()
        {
            yield return new WaitForSeconds(delay);
            rb.velocity = Vector2.zero;
            enemyManager.enemyLocomotion.enabled = true;
        }
    }
}
