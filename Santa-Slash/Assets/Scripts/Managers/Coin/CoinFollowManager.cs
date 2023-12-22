using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character.Coin
{
    public class CoinFollowManager : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rb;
        [SerializeField] float dropJumpForce = 6;
        [SerializeField] float minModifier = 3f;
        [SerializeField] float maxModifier = 6f;

        private Vector3 velocity = Vector3.zero;
        private bool isFollowing = false;

        private void OnEnable()
        {
            isFollowing = false;

            rb.AddForce(Vector2.up * dropJumpForce);

            StartCoroutine(AttemptToStartFollowing());
        }

        IEnumerator AttemptToStartFollowing()
        {
            yield return new WaitForSeconds(0.75f);

            isFollowing = true;
        }

        private void Update()
        {
            if (isFollowing)
            {
                transform.position = Vector3.SmoothDamp(transform.position, PlayerManager.Instance.transform.position, ref velocity, Time.deltaTime * Random.Range(minModifier, maxModifier));
            }
        }
    }
}
