using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace TranscendenceStudio.VFX
{
    public class VFXController : MonoBehaviour
    {
        [SerializeField] MMF_Player feedback;

        private ParticleSystem vfx;
        private System.Action<GameObject> releaseCallback;

        void Awake()
        {
            vfx = GetComponent<ParticleSystem>();
        }

        private void OnEnable()
        {
            if (feedback != null)
            {
                feedback.PlayFeedbacks();
            }
        }

        public void SetReleaseCallback(System.Action<GameObject> callback)
        {
            Debug.Log("SetReleaseCallback");
            releaseCallback = callback;
        }

        private void Update()
        {
            if (!vfx.IsAlive(true))
            {
                releaseCallback?.Invoke(gameObject);
            }
        }
    }
}
