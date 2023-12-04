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
        [SerializeField] EnemyLocomotion enemyLocomotion;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void PlayFeedback(GameObject sender)
        {
            StopAllCoroutines();
            enemyLocomotion.enabled = false;

            Debug.Log(transform.position);
            Debug.Log(sender.transform.position);
            Debug.Log(rb.velocity);

            Vector2 direction = (transform.position - sender.transform.position).normalized;
            rb.AddForce(direction * strength, ForceMode2D.Impulse);
            Debug.Log(rb.velocity);
            StartCoroutine(TimeToStopKnockback());
        }

        public IEnumerator TimeToStopKnockback()
        {
            yield return new WaitForSeconds(delay);
            rb.velocity = Vector2.zero;
            enemyLocomotion.enabled = true;
        }
    }
}
