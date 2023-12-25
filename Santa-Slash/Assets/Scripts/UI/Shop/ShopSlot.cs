using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using TranscendenceStudio.Items;
using TranscendenceStudio.Character;
using UnityEngine.UI;
using MoreMountains.Feedbacks;

namespace TranscendenceStudio.UI.ShopSystem
{
    public class ShopSlot : MonoBehaviour, IPointerClickHandler, ITooltip
    {
        [Header("Item")]
        [SerializeField] Item item;
        [SerializeField] Image itemIcon;

        [Header("Text")]
        [SerializeField] TextMeshProUGUI itemNameText;
        [SerializeField] TextMeshProUGUI itemPriceText;

        [Header("Feedback On Buy Item")]
        [SerializeField] MMF_Player buyItemFeedback;

        public void SetTitleAndPriceText()
        {
            itemNameText.SetText(Item.itemName);
            itemPriceText.SetText($"{Item.itemPrice}g");
        }

        public void SetItemIcon()
        {
            if (!itemIcon.enabled)
            {
                itemIcon.enabled = true;
            }

            itemIcon.sprite = item.itemIcon;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            // If the player has enough money -> buy, reduce money, add to inventory
            if (PlayerManager.Instance == null) return;

            if (PlayerManager.Instance.playerCurrency.Currency >= Item.itemPrice)
            {
                // Play NPC's Satisfied feedback
                if (UIManager.Instance.shopManager.CurrentNPCManager != null)
                {
                    UIManager.Instance.shopManager.CurrentNPCManager.PlaySatisfiedFeedback();
                }

                PlayerManager.Instance.playerCurrency.Currency -= Item.itemPrice;

                buyItemFeedback.PlayFeedbacks();

                UIManager.Instance.inventoryManager.AddItemToInventory(Item);
            }
        }

        public string GetTooltipTitle()
        {
            if (item != null)
            {
                return item.itemName;
            }

            return "";
        }

        public string GetTooltipDescription()
        {
            if (item != null)
            {
                return item.itemDescription;
            }

            return "";
        }

        public string GetTooltipPrice()
        {
            if (item != null)
            {
                return item.itemPrice.ToString();
            }

            return "";
        }

        public Item Item
        {
            get => item;
            set => item = value;
        }
    }
}
