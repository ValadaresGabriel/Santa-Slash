using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;

namespace TranscendenceStudio
{
    public class MouseManager : MonoBehaviour
    {
        private static MouseManager Instance;
        private InputSystemUIInputModule inputModule;

        private void Awake()
        {
            Instance = this;
            inputModule = GetComponent<InputSystemUIInputModule>();
        }

        public static Vector2 MousePosition => Instance.inputModule.point.action.ReadValue<Vector2>();
    }
}
