using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class PlayerManager : CharacterManager
    {
        public static PlayerManager Instance;

        public PlayerCurrency playerCurrency;
        public PlayerWeaponManager characterWeaponManager;
        public WeaponAnimatorManager weaponAnimatorManager;
        public PlayerHealth PlayerHealth { get; private set; }
        public PlayerStatsManager PlayerStatsManager { get; private set; }
        public PlayerLocomotion PlayerLocomotion { get; private set; }

        [Space(5)]
        [Header("Feedbacks")]
        public MMF_Player dealDamageFeedback;
        public MMF_Player takeDamageFeedback;
        public MMF_Player walkFeedback;
        [Space(5)]

        private bool isInInteractionArea = false;
        private bool isOnShop;
        private bool isOnInventory;
        private bool isInteracting = false;
        private bool isMouseOnInteractableObject = false;
        private bool isInBattle = false;
        public bool isAttacking = false;

        protected override void Awake()
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

            base.Awake();

            PlayerHealth = GetComponent<PlayerHealth>();
            playerCurrency = GetComponent<PlayerCurrency>();
            PlayerStatsManager = GetComponent<PlayerStatsManager>();
            PlayerLocomotion = GetComponent<PlayerLocomotion>();
        }

        public void EnableUIActions()
        {
            PlayerInputManager.Instance.EnableUIActions();
        }

        public void EnablePlayerActions()
        {
            PlayerInputManager.Instance.EnablePlayerActions();
        }

        public bool IsAttacking
        {
            get => isAttacking;
            set => isAttacking = value;
        }

        public bool IsInInteractionArea
        {
            get => isInInteractionArea;
            set => isInInteractionArea = value;
        }

        public bool IsOnShop
        {
            get => isOnShop;
            set => isOnShop = value;
        }

        public bool IsOnInventory
        {
            get => isOnInventory;
            set => isOnInventory = value;
        }

        public bool IsInteracting
        {
            get => isInteracting;
            set => isInteracting = value;
        }

        public bool IsInBattle
        {
            get => isInBattle;
            set
            {
                isInBattle = value;

                if (isInBattle)
                {
                    SoundManager.Instance.TransitionFromBackgroundMusicToBattleMusic();
                }
                else
                {
                    SoundManager.Instance.TransitionFromBattleMusicToBackgroundMusic();
                }
            }
        }

        public bool IsMouseOnInteractableObject
        {
            get => isMouseOnInteractableObject;
            set => isMouseOnInteractableObject = value;
        }
    }
}
