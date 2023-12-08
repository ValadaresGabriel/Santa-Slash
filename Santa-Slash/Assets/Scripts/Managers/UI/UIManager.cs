using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.UI
{
    public class UIManager : MonoBehaviour
    {
        private UIManager Instance;

        public PlayerUIManager playerUIManager;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }


    }
}
