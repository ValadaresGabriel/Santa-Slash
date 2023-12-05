using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class PlayerSFXManager : MonoBehaviour
    {
        private PlayerManager playerManager;

        private void Awake()
        {
            playerManager = GetComponent<PlayerManager>();
        }

        public void PlayWalkFeedback()
        {
            playerManager.walkFeedback.PlayFeedbacks();
        }
    }
}
