using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.VFX;
using UnityEngine;

namespace TranscendenceStudio.Pooling
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] float time = 0;
        [SerializeField] float repeatRate = 50f;
        [SerializeField] int spawnQuantity;
        [SerializeField] Transform[] spawnLocation;

        private void Awake()
        {
            InvokeRepeating(nameof(SpawnEnemy), time, repeatRate);
        }

        private void SpawnEnemy()
        {
            GameObject enemyInstance = EnemySpawnerManager.Instance.GetObject();

            int spawnIndex = Random.Range(0, spawnLocation.Length);
            Transform selectedSpawn = spawnLocation[spawnIndex];

            enemyInstance.transform.SetPositionAndRotation(selectedSpawn.position, Quaternion.identity);
        }
    }
}
