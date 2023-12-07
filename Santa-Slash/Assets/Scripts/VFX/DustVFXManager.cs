using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.VFX
{
    public class DustVFXManager : VFXManager
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
