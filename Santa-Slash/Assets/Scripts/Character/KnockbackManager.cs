using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;

namespace TranscendenceStudio
{
    public class KnockbackManager : MonoBehaviour
    {
        private Rigidbody2D rb;
        [SerializeField] float delay = 0.2f;
        public float strength = 2;
        private CharacterManager characterManager;

        private void Awake()
        {
            characterManager = GetComponent<CharacterManager>();
            rb = GetComponent<Rigidbody2D>();
        }

        public void PlayFeedback(GameObject sender)
        {
            StopAllCoroutines();
            characterManager.characterLocomotion.enabled = false;

            float strength;

            if (sender.transform.CompareTag("Player"))
            {
                strength = PlayerManager.Instance.characterWeaponManager.equippedWeapon.knockbackStrength;
            }
            else
            {
                strength = sender.GetComponent<KnockbackManager>().strength;
            }

            Vector2 direction = (transform.position - sender.transform.position).normalized;
            rb.AddForce(direction * strength, ForceMode2D.Impulse);
            StartCoroutine(TimeToStopKnockback());
        }

        public IEnumerator TimeToStopKnockback()
        {
            yield return new WaitForSeconds(delay);
            rb.velocity = Vector2.zero;
            characterManager.characterLocomotion.enabled = true;
        }
    }
}
