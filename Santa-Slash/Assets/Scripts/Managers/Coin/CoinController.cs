using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character.Coin
{
    public class CoinController : MonoBehaviour
    {
        private bool collidedWithPlayer = false;
        private System.Action<GameObject> releaseCallback;

        private void OnEnable()
        {
            collidedWithPlayer = false;
        }

        public void SetReleaseCallback(System.Action<GameObject> callback)
        {
            releaseCallback = callback;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (collidedWithPlayer) return;

            if (other.transform.CompareTag("Player"))
            {
                collidedWithPlayer = true;
                PlayerManager.Instance.playerCurrency.Currency += 1;
                releaseCallback?.Invoke(gameObject);
            }
        }
    }
}
