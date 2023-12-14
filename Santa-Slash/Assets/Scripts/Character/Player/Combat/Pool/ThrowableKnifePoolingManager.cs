using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Pooling;
using TranscendenceStudio.VFX;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class ThrowableKnifePoolingManager : ObjectPoolingManager
    {
        public static ThrowableKnifePoolingManager Instance { get; private set; }

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
