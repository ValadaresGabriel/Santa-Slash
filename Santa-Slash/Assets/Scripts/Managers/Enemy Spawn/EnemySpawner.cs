using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.VFX;
using UnityEngine;

namespace TranscendenceStudio.Pooling
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] int enemiesToSpawn = 5;
        [SerializeField] float repeatRate = 50f;
        [SerializeField] Transform[] spawnLocation;
        private bool playerEnteredArea = false;

        private void SpawnEnemy()
        {
            int enemyChoice = Random.Range(1, 4);
            GameObject enemyInstance = null;

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                switch (enemyChoice)
                {
                    case 1:
                        enemyInstance = SlimeSpawnerManager.Instance.GetObject();
                        break;
                    case 2:
                        enemyInstance = GolemSpawnerManager.Instance.GetObject();
                        break;
                    case 3:
                        enemyInstance = DemonSpawnerManager.Instance.GetObject();
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (playerEnteredArea) return;

            if (other.transform.CompareTag("Player"))
            {
                playerEnteredArea = true;
                InvokeRepeating(nameof(SpawnEnemy), 0, repeatRate);
            }
        }
    }
}
