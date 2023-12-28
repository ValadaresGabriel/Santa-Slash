using System;
using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Items;
using UnityEngine;

namespace TranscendenceStudio.UI.Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] Transform content;
        private List<InventorySlot> inventorySlots = new();
        private int equippedItemIndex = -1;

        public event Action<Item> EquipItemEvent;

        private void Awake()
        {
            int slotNumber = 1;
            foreach (Transform inventorySlotsTransform in content)
            {
                if (slotNumber == 10) slotNumber = 0;

                InventorySlot inventorySlot = inventorySlotsTransform.GetComponent<InventorySlot>();
                inventorySlot.SetSlotNumber(slotNumber++);
                inventorySlots.Add(inventorySlot);
            }
        }

        private void Start()
        {
            PlayerInputManager.Instance.EquipEvent1 += () => EquipItem(1);
            PlayerInputManager.Instance.EquipEvent2 += () => EquipItem(2);
            PlayerInputManager.Instance.EquipEvent3 += () => EquipItem(3);
            PlayerInputManager.Instance.EquipEvent4 += () => EquipItem(4);
            PlayerInputManager.Instance.EquipEvent5 += () => EquipItem(5);
            PlayerInputManager.Instance.EquipEvent6 += () => EquipItem(6);
            PlayerInputManager.Instance.EquipEvent7 += () => EquipItem(7);
            PlayerInputManager.Instance.EquipEvent8 += () => EquipItem(8);
            PlayerInputManager.Instance.EquipEvent9 += () => EquipItem(9);
            PlayerInputManager.Instance.EquipEvent0 += () => EquipItem(0);
        }

        public void AddItemToInventory(Item item)
        {
            if (VerifyIfHasItemAlready(item))
            {
                Debug.Log($"<color=yellow>Player already have {item.itemName} in Inventory</color>");
                return;
            }

            foreach (InventorySlot inventorySlot in inventorySlots)
            {
                if (inventorySlot.item == null)
                {
                    Debug.Log($"<color=green>Added {item.itemName} to Inventory</color>");
                    inventorySlot.AddItemToSlot(item);
                    break;
                }
            }
        }

        private bool VerifyIfHasItemAlready(Item item)
        {
            foreach (InventorySlot inventorySlot in inventorySlots)
            {
                if (inventorySlot.item == item)
                {
                    return true;
                }
            }

            return false;
        }

        public void EquipItem(int itemSlotIndex)
        {
            if (inventorySlots.Count <= 0) return;

            if (itemSlotIndex - 1 == equippedItemIndex || (itemSlotIndex == 0 && equippedItemIndex == 9))
            {
                Debug.LogWarning("<color=yellow>Avoid to equip the same item</color>");
                return;
            }

            if (inventorySlots[itemSlotIndex - 1].item == null || (itemSlotIndex == 0 && inventorySlots[9].item == null))
            {
                Debug.LogWarning("<color=yellow>The item is NULL, cannot equip it</color>");
                return;
            }

            if (equippedItemIndex >= 0)
            {
                UnequipItem();
            }

            if (itemSlotIndex == 0)
            {
                equippedItemIndex = 9;
                inventorySlots[equippedItemIndex].EquipItem();
                return;
            }

            equippedItemIndex = itemSlotIndex - 1;

            inventorySlots[equippedItemIndex].EquipItem();

            EquipItemEvent?.Invoke(inventorySlots[equippedItemIndex].item);
        }

        public void UnequipItem()
        {
            inventorySlots[equippedItemIndex].Unequip();
        }

        private void OnDestroy()
        {
            PlayerInputManager.Instance.EquipEvent1 -= () => EquipItem(1);
            PlayerInputManager.Instance.EquipEvent2 -= () => EquipItem(2);
            PlayerInputManager.Instance.EquipEvent3 -= () => EquipItem(3);
            PlayerInputManager.Instance.EquipEvent4 -= () => EquipItem(4);
            PlayerInputManager.Instance.EquipEvent5 -= () => EquipItem(5);
            PlayerInputManager.Instance.EquipEvent6 -= () => EquipItem(6);
            PlayerInputManager.Instance.EquipEvent7 -= () => EquipItem(7);
            PlayerInputManager.Instance.EquipEvent8 -= () => EquipItem(8);
            PlayerInputManager.Instance.EquipEvent9 -= () => EquipItem(9);
            PlayerInputManager.Instance.EquipEvent0 -= () => EquipItem(0);
        }
    }
}
