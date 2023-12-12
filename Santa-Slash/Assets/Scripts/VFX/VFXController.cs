using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.VFX
{
    public class VFXController : MonoBehaviour
    {
        private ParticleSystem vfx;
        private System.Action<GameObject> releaseCallback;

        void Awake()
        {
            vfx = GetComponent<ParticleSystem>();
        }

        public void SetReleaseCallback(System.Action<GameObject> callback)
        {
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
