using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio
{
    public class CursorManager : MonoBehaviour
    {
        private static CursorManager Instance;

        [SerializeField] Texture2D defaultCursorTexture;
        [SerializeField] Texture2D onClickCursorTexture;
        [SerializeField] Texture2D onDragCursorTexture;
        [SerializeField] Vector2 hotSpot = Vector2.zero;

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

        private void Start()
        {
            SetDefaultCursor();
        }

        public static void SetDefaultCursor()
        {
            Cursor.SetCursor(Instance.defaultCursorTexture, Instance.hotSpot, CursorMode.Auto);
        }

        public static void SetOnClickCursor()
        {
            Cursor.SetCursor(Instance.onClickCursorTexture, Instance.hotSpot, CursorMode.Auto);
        }

        public static void SetOnDragCursor()
        {
            Cursor.SetCursor(Instance.onDragCursorTexture, Instance.hotSpot, CursorMode.Auto);
        }
    }
}
