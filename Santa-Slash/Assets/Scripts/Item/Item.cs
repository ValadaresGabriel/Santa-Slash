using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Items
{
    public enum ItemType
    {
        Clothing,
        Hair,
        Hat,
        Weapon,
    }

    public class Item : ScriptableObject
    {
        public ItemType itemType;
        public Sprite itemIcon;
        public string itemName;
        public string itemDescription;
        public int itemPrice;
    }
}
