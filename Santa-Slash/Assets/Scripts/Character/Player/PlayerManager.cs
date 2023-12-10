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
        public CharacterWeaponManager characterWeaponManager;
        public WeaponAnimatorManager weaponAnimatorManager;
        public PlayerStatsManager playerStatsManager { get; private set; }
        public PlayerLocomotion playerLocomotion { get; private set; }

        [Space(5)]
        [Header("Feedbacks")]
        public MMF_Player playerFeedback;
        public MMF_Player walkFeedback;
        [Space(5)]

        private bool isOnShop;
        private bool isOnInventory;
        private bool isInteracting = false;

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

            playerCurrency = GetComponent<PlayerCurrency>();
            playerStatsManager = GetComponent<PlayerStatsManager>();
            playerLocomotion = GetComponent<PlayerLocomotion>();

            // PlayerInputManager.Instance.OpenInventoryEvent += OpenInventory;
        }

        public void EnableUIActions()
        {
            // PlayerInputManager.Instance.EnableUIActions();
        }

        public void EnablePlayerActions()
        {
            // PlayerInputManager.Instance.EnablePlayerActions();
        }

        private void OpenInventory()
        {
            if (IsInteracting && !isOnInventory) return;

            if (!isOnInventory)
            {
                IsInteracting = true;
                // UIManager.OpenInventory();
                return;
            }

            // UIManager.CloseInventory();
            IsInteracting = false;
        }

        private void OnDestroy()
        {
            // PlayerInputManager.Instance.OpenInventoryEvent -= OpenInventory;
        }

        public void SetIsAttackingToFalse()
        {
            IsAttacking = false;
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
    }
}
