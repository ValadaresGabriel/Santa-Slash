using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using TranscendenceStudio.Character.DialogSystem;
using TranscendenceStudio.Items;
using TranscendenceStudio.UI.Inventory;
using TranscendenceStudio.UI.ShopSystem;
using UnityEngine;

namespace TranscendenceStudio.UI
{
    public enum Interaction
    {
        Dialog,
        Shop,
    }

    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        [Header("Player UI Manager")]
        public PlayerUIManager playerUIManager;

        [Header("Inventory Manager")]
        public InventoryManager inventoryManager;

        [Header("Dialog Manager")]
        public DialogManager dialogManager;

        [Header("Shop Manager")]
        public ShopManager shopManager;

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

        public static void Interact(Interaction interaction, NPCManager npcManager = null)
        {
            if (PlayerManager.Instance.IsInteracting)
            {
                Debug.Log("The Player is already interacting!");
                return;
            }

            Debug.Log("Interact");

            switch (interaction)
            {
                case Interaction.Dialog:
                    PlayerManager.Instance.EnableUIActions();
                    OpenDialog(npcManager);
                    break;
                case Interaction.Shop:
                    OpenShop(npcManager);
                    break;
            }

            PlayerManager.Instance.IsInteracting = true;
        }

        public static void OpenDialog(NPCManager npcManager)
        {
            Instance.dialogManager.OpenDialog(npcManager);
        }

        public static void CloseDialog()
        {
            PlayerManager.Instance.EnablePlayerActions();
            Instance.dialogManager.CloseDialog();
            PlayerManager.Instance.IsInteracting = false;
        }

        public static void OpenShop(NPCManager npcManager)
        {
            Instance.shopManager.OpenShop(npcManager);
        }

        public static void CloseShop()
        {
            Instance.shopManager.CloseShop();
            PlayerManager.Instance.IsInteracting = false;
            PlayerManager.Instance.IsOnShop = false;
        }
    }
}
