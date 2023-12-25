using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace TranscendenceStudio
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance { get; private set; }
        [SerializeField] MMF_Player battlePlayer;
        [SerializeField] MMF_Player backgroundPlayer;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // Background Music -> Battle Music
        public void TransitionFromBackgroundMusicToBattleMusic()
        {
            battlePlayer.PlayFeedbacks();
        }

        // Battle Music -> Background Music
        public void TransitionFromBattleMusicToBackgroundMusic()
        {
            backgroundPlayer.PlayFeedbacks();
        }
    }
}
