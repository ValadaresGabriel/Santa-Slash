using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TranscendenceStudio
{
    public class PlayerInputManager : MonoBehaviour, PlayerControls.IPlayerActions, PlayerControls.IDialogActions
    {
        public static PlayerInputManager Instance { get; private set; }

        [Header("Values")]
        public Vector2 MovementValue;
        public Vector2 MouseWheelValue;
        private Vector2 MousePositionValue;

        // Events
        public event Action AttackEvent;
        public event Action AbilityEvent;
        public event Action InteractEvent;

        public event Action EquipEvent1;
        public event Action EquipEvent2;
        public event Action EquipEvent3;
        public event Action EquipEvent4;
        public event Action EquipEvent5;
        public event Action EquipEvent6;
        public event Action EquipEvent7;
        public event Action EquipEvent8;
        public event Action EquipEvent9;
        public event Action EquipEvent0;

        // Dialog
        public event Action NextDialogEvent;

        // Main Camera -> is being used to get the mouse's position
        private Camera mainCamera;

        private PlayerControls playerControls;

        private bool enablePlayerActions;
        private bool enableUIActions;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            mainCamera = Camera.main;

            playerControls = new PlayerControls();

            playerControls.Player.SetCallbacks(this);
            playerControls.Enable();
        }

        private void Update()
        {
            if (enableUIActions)
            {
                enableUIActions = false;
                playerControls.Player.RemoveCallbacks(this);

                playerControls.Dialog.SetCallbacks(this);
            }

            if (enablePlayerActions)
            {
                enablePlayerActions = false;
                playerControls.Dialog.RemoveCallbacks(this);

                playerControls.Player.SetCallbacks(this);
            }
        }

        public void EnableUIActions()
        {
            enablePlayerActions = false;
            enableUIActions = true;
        }

        public void EnablePlayerActions()
        {
            enablePlayerActions = true;
            enableUIActions = false;
        }

        public Vector2 GetMousePositionValue()
        {
            Vector3 mousePosition = MousePositionValue;
            mousePosition.z = mainCamera.nearClipPlane;
            return mainCamera.ScreenToWorldPoint(mousePosition);
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            MovementValue = context.ReadValue<Vector2>();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                AttackEvent?.Invoke();
            }
        }

        public void OnAbility(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                AbilityEvent?.Invoke();
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                InteractEvent?.Invoke();
            }
        }

        public void OnMousePosition(InputAction.CallbackContext context)
        {
            MousePositionValue = context.ReadValue<Vector2>();
        }

        #region Inventory Events
        public void On_1(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                EquipEvent1?.Invoke();
            }
        }

        public void On_2(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                EquipEvent2?.Invoke();
            }
        }

        public void On_3(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                EquipEvent3?.Invoke();
            }
        }

        public void On_4(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                EquipEvent4?.Invoke();
            }
        }

        public void On_5(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                EquipEvent5?.Invoke();
            }
        }

        public void On_6(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                EquipEvent6?.Invoke();
            }
        }

        public void On_7(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                EquipEvent7?.Invoke();
            }
        }

        public void On_8(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                EquipEvent8?.Invoke();
            }
        }

        public void On_9(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                EquipEvent9?.Invoke();
            }
        }

        public void On_0(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                EquipEvent0?.Invoke();
            }
        }
        #endregion

        public void OnMouseWheel(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                MouseWheelValue = context.ReadValue<Vector2>();
            }
        }

        // Dialog
        public void OnNextDialog(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                NextDialogEvent?.Invoke();
            }
        }
    }
}
