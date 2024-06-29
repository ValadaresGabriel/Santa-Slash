using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character.Coin
{
    public class CoinFollowManager : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rb;
        [SerializeField] float dropJumpForce = 6;

        private Vector3 velocity = Vector3.zero;
        private bool isFollowing = false;

        private void OnEnable()
        {
            isFollowing = false;

            rb.bodyType = RigidbodyType2D.Dynamic;

            rb.AddForce(Vector2.up * dropJumpForce, ForceMode2D.Impulse);

            StartCoroutine(AttemptToStartFollowing());
        }

        IEnumerator AttemptToStartFollowing()
        {
            yield return new WaitForSeconds(0.75f);

            rb.bodyType = RigidbodyType2D.Static;

            isFollowing = true;
        }

        private void Update()
        {
            if (isFollowing)
            {
                Vector3 direction = PlayerManager.Instance.gameObject.transform.position - transform.position;
                direction.Normalize();

                transform.Translate(Time.deltaTime * 6 * direction);
            }
        }
    }
}
