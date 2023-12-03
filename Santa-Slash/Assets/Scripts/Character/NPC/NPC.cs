using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character.DialogSystem;
using TranscendenceStudio.ShopSystem;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    [CreateAssetMenu(fileName = "New NPC", menuName = "Character/NPC")]
    public class NPC : ScriptableObject
    {
        public string npcName;
        public bool hasShop;
        public Shop npcShop;
        public Dialog dialog;
    }
}
