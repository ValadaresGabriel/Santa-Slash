using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.VFX;
using UnityEngine;

namespace TranscendenceStudio
{
    public class WallManager : MonoBehaviour, IHittable
    {
        [SerializeField] int health = 1;
        [SerializeField] Collider2D wallCollider;
        [SerializeField] SpriteRenderer spriteRenderer;
        private bool isDestroyed = false;

        private void Update()
        {
            if (isDestroyed) return;

            if (health <= 0)
            {
                isDestroyed = true;
                wallCollider.enabled = false;

                Color newColor = Color.black;
                newColor.a = 0;

                spriteRenderer.color = newColor;

                GameObject damageVFX = DustVFXManager.Instance.GetVFX();
                damageVFX.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
                damageVFX.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
            }
        }

        public void Hit(int damage, GameObject sender)
        {
            health -= damage;
        }

        public Vector3 TargetPosition()
        {
            return transform.position;
        }
    }
}
