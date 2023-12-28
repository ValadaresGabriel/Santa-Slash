using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace TranscendenceStudio
{
    public class ChestManager : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] Sprite openSprite;
        [SerializeField] MMF_Player chestFeedback;
        [SerializeField] bool isOpened = false;

        public void OpenChest()
        {
            if (isOpened) return;

            isOpened = true;
            spriteRenderer.sprite = openSprite;
            chestFeedback.PlayFeedbacks();
        }
    }
}
