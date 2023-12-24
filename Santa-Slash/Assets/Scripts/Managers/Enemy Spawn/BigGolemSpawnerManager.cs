using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Pooling;
using UnityEngine;

namespace TranscendenceStudio.VFX
{
    public class BigGolemSpawnerManager : ObjectPoolingManager
    {
        public static BigGolemSpawnerManager Instance { get; private set; }

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
