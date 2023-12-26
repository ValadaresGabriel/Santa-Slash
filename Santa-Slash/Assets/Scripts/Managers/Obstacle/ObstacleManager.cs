using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Pooling;
using TranscendenceStudio.VFX;
using UnityEngine;
using UnityEngine.Events;

namespace TranscendenceStudio
{
    public enum ObstacleType
    {
        Wall,
        Tree,
    }

    public class ObstacleManager : MonoBehaviour, IHittable
    {
        [SerializeField] protected ObstacleType obstacleType = ObstacleType.Wall;
        [SerializeField] protected int health = 1;
        [SerializeField] protected Collider2D obstacleCollider;
        [SerializeField] protected SpriteRenderer spriteRenderer;
        [SerializeField] protected int weaponDurabilityDamage = 1;
        [SerializeField] protected ParticleSystem takeDamageParticles;
        public UnityEvent OnDeath;

        public int GetWeaponDurabilityDamage()
        {
            return weaponDurabilityDamage;
        }

        public virtual void Hit(int damage, GameObject sender)
        {
            health -= damage;

            if (takeDamageParticles != null)
            {
                takeDamageParticles.Play();
            }

            if (health <= 0)
            {
                OnDeath?.Invoke();

                obstacleCollider.enabled = false;

                Color newColor = Color.black;
                newColor.a = 0;

                spriteRenderer.color = newColor;

                GameObject destructionVFX = null;

                switch (obstacleType)
                {
                    case ObstacleType.Wall:
                        destructionVFX = DustVFXManager.Instance.GetObject();
                        break;
                    case ObstacleType.Tree:
                        destructionVFX = TreeVFXManager.Instance.GetObject();
                        break;
                }

                // GameObject destructionVFX = getDestructionVFX[obstacleType].GetObject();
                destructionVFX.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
                destructionVFX.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
            }
        }

        public Vector3 TargetPosition()
        {
            return transform.position;
        }
    }
}
