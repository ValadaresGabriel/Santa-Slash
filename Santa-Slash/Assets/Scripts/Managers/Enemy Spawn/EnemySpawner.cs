using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.VFX;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace TranscendenceStudio.Pooling
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] BoxCollider2D firstPlayerDetectionArea;
        [SerializeField] int enemiesToSpawn = 5;
        [SerializeField] float repeatRate = 50f;
        [SerializeField] Transform[] spawnLocation;
        [SerializeField] Light2D treeLight;
        private bool playerEnteredArea = false;
        private bool canTurnOffLight = false;

        private void Update()
        {
            if (!canTurnOffLight) return;

            treeLight.intensity -= Time.deltaTime;

            if (treeLight.intensity <= 0)
            {
                treeLight.intensity = 0;
                canTurnOffLight = false;
            }
        }

        private void SpawnEnemy()
        {
            GameObject enemyInstance = null;

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                int enemyChoice = Random.Range(1, 4);

                switch (enemyChoice)
                {
                    case 1:
                        enemyInstance = SlimeSpawnerManager.Instance.GetObject();
                        break;
                    case 2:
                        enemyInstance = GolemSpawnerManager.Instance.GetObject();
                        break;
                    case 3:
                        enemyInstance = GoblinSpawnerManager.Instance.GetObject();
                        break;
                    case 4:
                        enemyInstance = DinosaurSpawnerManager.Instance.GetObject();
                        break;
                }

                int spawnIndex = Random.Range(0, spawnLocation.Length);
                Transform selectedSpawn = spawnLocation[spawnIndex];

                enemyInstance.transform.SetPositionAndRotation(selectedSpawn.position, Quaternion.identity);
            }
        }

        public void StopSpawning()
        {
            CancelInvoke();
            canTurnOffLight = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (playerEnteredArea) return;

            if (other.transform.CompareTag("Player"))
            {
                playerEnteredArea = true;
                InvokeRepeating(nameof(SpawnEnemy), 0, repeatRate);
                firstPlayerDetectionArea.enabled = false;
            }
        }
    }
}
