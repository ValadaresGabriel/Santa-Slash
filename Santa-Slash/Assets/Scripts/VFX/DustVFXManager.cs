using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Pooling;
using UnityEngine;

namespace TranscendenceStudio.VFX
{
    public class DustVFXManager : ObjectPoolingManager
    {
        public static DustVFXManager Instance { get; private set; }

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
