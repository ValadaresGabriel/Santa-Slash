using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TranscendenceStudio
{
    public class PlayerInputManager : MonoBehaviour, PlayerControls.IPlayerActions
    {
        public static PlayerInputManager Instance { get; private set; }

        [Header("Values")]
        public Vector2 MovementValue;
        private Vector2 MousePositionValue;

        // Events
        public event Action AttackEvent;
        public event Action InteractEvent;

        // Main Camera -> is being used to get the mouse's position
        private Camera mainCamera;

        private PlayerControls playerControls;

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
    }
}
