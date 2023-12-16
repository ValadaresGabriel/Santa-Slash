using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Inventory;
using UnityEngine;

namespace TranscendenceStudio.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        public PlayerUIManager playerUIManager;
        public InventoryManager InventoryManager;

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
