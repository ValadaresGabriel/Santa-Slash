using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TranscendenceStudio.UI
{
    public class ScrollManager : MonoBehaviour
    {
        [SerializeField] Scrollbar scrollbar;
        [SerializeField] ScrollRect scrollRect;

        private void Start()
        {
            scrollbar.value = 1;
        }

        public void RefreshScroll()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(scrollRect.content);
        }
    }
}
