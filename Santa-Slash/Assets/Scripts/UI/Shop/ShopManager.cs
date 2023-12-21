using System.Collections;
using System.Collections.Generic;
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

        public void OpenShop(List<Item> items)
        {
            shopGameObject.SetActive(true);

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

            foreach (Transform item in content)
            {
                Destroy(item.gameObject);
            }
        }
    }
}
