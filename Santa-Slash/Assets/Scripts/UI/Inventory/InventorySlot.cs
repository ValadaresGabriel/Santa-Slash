using System.Collections;
using System.Collections.Generic;
using TMPro;
using TranscendenceStudio.Items;
using UnityEngine;
using UnityEngine.UI;

namespace TranscendenceStudio.UI.Inventory
{
    public class InventorySlot : MonoBehaviour, ITooltip
    {
        [SerializeField] Image background;
        [SerializeField] Image itemIcon;
        [SerializeField] TextMeshProUGUI equippedTag;
        [SerializeField] TextMeshProUGUI slotNumber;
        public Item item;
        public bool isEquipped;
        private Color originalColor;

        private void Start()
        {
            originalColor = background.color;
        }

        public void AddItemToSlot(Item itemToAdd)
        {
            item = itemToAdd;
            itemIcon.sprite = item.itemIcon;

            Color color = Color.white;
            color.a = 1;

            itemIcon.color = color;
        }

        public void EquipItem()
        {
            isEquipped = true;
            background.color = new Color32(195, 169, 36, 255);
            itemIcon.color = new Color32(255, 255, 255, 255);
            equippedTag.SetText("E");
        }

        public void Unequip()
        {
            isEquipped = false;
            background.color = originalColor;
            // itemIcon.color = new Color32(255, 255, 255, 255);
            equippedTag.SetText("");
        }

        public void SetSlotNumber(int number)
        {
            slotNumber.SetText(number.ToString());
        }

        public string GetTooltipTitle()
        {
            return item.itemName;
        }

        public string GetTooltipDescription()
        {
            return item.itemDescription;
        }

        public string GetTooltipPrice()
        {
            return item.itemPrice.ToString();
        }
    }
}
