using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using TranscendenceStudio.ShopSystem;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class NPCManager : MonoBehaviour
    {
        public NPC npc;
        [SerializeField] MMF_Player hiFeedback;
        [SerializeField] MMF_Player byeFeedback;
        [SerializeField] MMF_Player satisfiedFeedback;
        [SerializeField] MMF_Player angryFeedback;

        public void PlayHiFeedback()
        {
            hiFeedback.PlayFeedbacks();
        }

        public void PlayByeFeedback()
        {
            byeFeedback.PlayFeedbacks();
        }

        public void PlaySatisfiedFeedback()
        {
            satisfiedFeedback.PlayFeedbacks();
        }

        public void PlayAngryFeedback()
        {
            angryFeedback.PlayFeedbacks();
        }
    }
}
