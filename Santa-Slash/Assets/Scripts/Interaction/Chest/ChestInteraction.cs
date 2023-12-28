using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TranscendenceStudio
{
    public class ChestInteraction : Interaction
    {
        [SerializeField] ChestManager chestManager;

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);

            chestManager.OpenChest();
        }
    }
}
