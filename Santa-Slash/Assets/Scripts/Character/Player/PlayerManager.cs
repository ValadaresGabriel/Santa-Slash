using System.Collections;
using System.Collections.Generic;
// using TranscendenceStudio.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TranscendenceStudio.Character
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;

        public PlayerCurrency playerCurrency;
        public PlayerEquipItem playerEquipItem;
        public CharacterAnimatorManager characterAnimatorManager;
        public CharacterWeaponManager characterWeaponManager;
        public WeaponAnimatorManager weaponAnimatorManager;

        private bool isOnShop;
        private bool isOnInventory;
        private bool isInteracting = false;
        private bool isAttacking = false;

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

            playerCurrency = GetComponent<PlayerCurrency>();
            playerEquipItem = GetComponent<PlayerEquipItem>();
            characterAnimatorManager = GetComponent<CharacterAnimatorManager>();

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

        public bool IsAttacking
        {
            get => isAttacking;
            set => isAttacking = value;
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
