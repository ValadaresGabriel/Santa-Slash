using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using TranscendenceStudio.Pooling;
using UnityEngine;

public class EnemyDropManager : MonoBehaviour
{
    private EnemyManager enemyManager;

    private void Awake()
    {
        enemyManager = GetComponent<EnemyManager>();
    }

    public void SpawnDrop()
    {
        for (int i = 0; i < enemyManager.enemy.dropQuantity; i++)
        {
            GameObject coinInstance = CoinSpawnerManager.Instance.GetObject();
            coinInstance.transform.SetPositionAndRotation(new Vector3(transform.position.x + Random.Range(0, 2), transform.position.y + Random.Range(0, 2)), Quaternion.identity);
        }
    }
}
