using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.VFX;
using UnityEngine;

namespace TranscendenceStudio
{
    public class EnemySpawnerTreeManager : ObstacleManager
    {
        [SerializeField] ParticleSystem deathTransitionParticles;
        [SerializeField] ParticleSystem deathVFX;
        private bool isDead = false;
        private bool isPlayingDeathCoroutine = false;

        private void Update()
        {
            if (isPlayingDeathCoroutine) return;

            if (isDead)
            {
                if (deathTransitionParticles.isStopped)
                {
                    StartCoroutine(Death());
                }
            }
        }

        private IEnumerator Death()
        {
            isPlayingDeathCoroutine = true;

            Time.timeScale = 0;

            yield return new WaitForSecondsRealtime(0.05f);

            Time.timeScale = 1;

            Color newColor = Color.black;
            newColor.a = 0;

            spriteRenderer.color = newColor;

            deathVFX.Play();
        }

        public override void Hit(int damage, GameObject sender)
        {
            health -= damage;

            if (takeDamageParticles != null)
            {
                takeDamageParticles.Play();
            }

            if (health <= 0)
            {
                isDead = true;

                OnDeath?.Invoke();

                obstacleCollider.enabled = false;

                // Color newColor = Color.black;
                // newColor.a = 0;

                // spriteRenderer.color = newColor;

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
    }
}
