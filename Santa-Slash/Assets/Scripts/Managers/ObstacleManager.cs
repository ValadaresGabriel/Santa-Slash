using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Pooling;
using TranscendenceStudio.VFX;
using UnityEngine;

namespace TranscendenceStudio
{
    public enum ObstacleType
    {
        Wall,
        Tree,
    }

    public class ObstacleManager : MonoBehaviour, IHittable
    {
        [SerializeField] ObstacleType obstacleType = ObstacleType.Wall;
        [SerializeField] int health = 1;
        [SerializeField] Collider2D obstacleCollider;
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] int weaponDurabilityDamage = 1;

        public int GetWeaponDurabilityDamage()
        {
            return weaponDurabilityDamage;
        }

        public void Hit(int damage, GameObject sender)
        {
            health -= damage;

            if (health <= 0)
            {
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
