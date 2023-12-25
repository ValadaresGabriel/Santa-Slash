using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using TranscendenceStudio.Items;
using UnityEngine;

namespace TranscendenceStudio.UI.ShopSystem
{
    public class ShopManager : MonoBehaviour
    {
        [Header("Shop Settings")]
        [SerializeField] GameObject shopGameObject;
        [SerializeField] Transform content;

        [Header("Shop Slot")]
        [SerializeField] GameObject shopSlotPrefab;
        [SerializeField] ScrollManager scrollManager;

        public NPCManager CurrentNPCManager { get; private set; }

        public void OpenShop(NPCManager npcManager)
        {
            shopGameObject.SetActive(true);

            CurrentNPCManager = npcManager;
            List<Item> items = npcManager.npc.npcShop.itemsToSell;

            foreach (Item item in items)
            {
                GameObject shopSlotInstance = Instantiate(shopSlotPrefab, content);
                ShopSlot shopSlot = shopSlotInstance.GetComponent<ShopSlot>();

                shopSlot.Item = item;
                shopSlot.SetItemIcon();

                shopSlot.SetTitleAndPriceText();
            }

            scrollManager.RefreshScroll();
        }

        public void AttemptToCloseShop()
        {
            UIManager.CloseShop();
        }

        public void CloseShop()
        {
            shopGameObject.SetActive(false);

            // Play NPC's Bye feedback
            CurrentNPCManager.PlayByeFeedback();

            CurrentNPCManager = null;

            foreach (Transform item in content)
            {
                Destroy(item.gameObject);
            }
        }
    }
}
