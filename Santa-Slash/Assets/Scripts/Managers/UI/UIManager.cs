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

        public static void Interact(Interaction interaction, NPC npc = null, List<Item> items = null)
        {
            if (PlayerManager.Instance.IsInteracting)
            {
                Debug.Log("The Player is already interacting!");
                return;
            }

            switch (interaction)
            {
                case Interaction.Dialog:
                    PlayerManager.Instance.EnableUIActions();
                    OpenDialog(npc);
                    break;
                case Interaction.Shop:
                    OpenShop(items);
                    break;
            }

            PlayerManager.Instance.IsInteracting = true;
        }

        public static void OpenDialog(NPC npc)
        {
            Instance.dialogManager.OpenDialog(npc);
        }

        public static void CloseDialog()
        {
            PlayerManager.Instance.EnablePlayerActions();
            Instance.dialogManager.CloseDialog();
            PlayerManager.Instance.IsInteracting = false;
        }

        public static void OpenShop(List<Item> items)
        {
            Instance.shopManager.OpenShop(items);
        }

        public static void CloseShop()
        {
            Instance.shopManager.CloseShop();
            PlayerManager.Instance.IsInteracting = false;
            PlayerManager.Instance.IsOnShop = false;
        }
    }
}
