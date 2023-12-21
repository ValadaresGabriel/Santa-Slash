using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Items;
using UnityEngine;

namespace TranscendenceStudio.ShopSystem
{
    [CreateAssetMenu(fileName = "New Shop", menuName = "Shop")]
    public class Shop : ScriptableObject
    {
        public List<Item> itemsToSell;
    }
}
