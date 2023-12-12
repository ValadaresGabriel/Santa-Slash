using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Pooling;
using TranscendenceStudio.VFX;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class SkillsPoolingManager : ObjectPoolingManager
    {
        public static SkillsPoolingManager Instance { get; private set; }

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
