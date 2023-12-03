using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Items;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class PlayerEquipItem : MonoBehaviour
    {
        [Header("Equipped Type Items")]
        public bool isClothingEquipped = false;
        public bool isHairEquipped = false;
        public bool isHatEquipped = false;

        [Header("Clothing")]
        [SerializeField] SpriteRenderer clothingSpriteRenderer;
        [SerializeField] Animator clothingRuntimeAnimator;

        [Header("Hair")]
        [SerializeField] SpriteRenderer hairSpriteRenderer;
        [SerializeField] Animator hairRuntimeAnimator;

        [Header("Hat")]
        [SerializeField] SpriteRenderer hatSpriteRenderer;
        [SerializeField] Animator hatRuntimeAnimator;

        public void EquipItem(Item item)
        {
            switch (item.itemType)
            {
                case ItemType.Clothing:
                    clothingSpriteRenderer.sprite = item.itemIcon;
                    clothingRuntimeAnimator.runtimeAnimatorController = (item as Clothing).animator;
                    isClothingEquipped = true;
                    break;
                case ItemType.Hair:
                    hairSpriteRenderer.sprite = item.itemIcon;
                    hairRuntimeAnimator.runtimeAnimatorController = (item as Clothing).animator;
                    isHairEquipped = true;
                    break;
                case ItemType.Hat:
                    hatSpriteRenderer.sprite = item.itemIcon;
                    hatRuntimeAnimator.runtimeAnimatorController = (item as Clothing).animator;
                    isHatEquipped = true;
                    break;
            }
        }

        public void UnequipItem(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Clothing:
                    clothingRuntimeAnimator.runtimeAnimatorController = null;
                    clothingSpriteRenderer.sprite = null;
                    isClothingEquipped = false;
                    break;
                case ItemType.Hair:
                    hairRuntimeAnimator.runtimeAnimatorController = null;
                    hairSpriteRenderer.sprite = null;
                    isHairEquipped = false;
                    break;
                case ItemType.Hat:
                    hatRuntimeAnimator.runtimeAnimatorController = null;
                    hatSpriteRenderer.sprite = null;
                    isHatEquipped = false;
                    break;
            }
        }
    }
}
