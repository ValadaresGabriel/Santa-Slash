using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class ThrowableWeaponDamageCollider : WeaponDamageColliderManager
    {
        private System.Action<GameObject> releaseCallback;
        private float timer = 0;

        private void OnEnable()
        {
            timer = 0;
        }

        private void Update()
        {
            if (timer < 3)
            {
                timer += Time.deltaTime;
                if (timer >= 3)
                {
                    releaseCallback?.Invoke(gameObject);
                }
            }
        }


        public void SetReleaseCallback(System.Action<GameObject> callback)
        {
            releaseCallback = callback;
        }

        protected override void DamageTarget(IHittable hittable)
        {
            base.DamageTarget(hittable);
        }
    }
}
