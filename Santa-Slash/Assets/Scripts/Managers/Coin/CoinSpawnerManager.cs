using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Pooling
{
    public class CoinSpawnerManager : ObjectPoolingManager
    {
        public static CoinSpawnerManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
