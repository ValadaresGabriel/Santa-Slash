using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.VFX
{
    public class HitVFXManager : VFXManager
    {
        public static HitVFXManager Instance { get; private set; }

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
