using UnityEngine;

namespace ClothGravity.UI
{
    public class TooltipManager : MonoBehaviour
    {
        private static TooltipManager Instance;

        [SerializeField] Tooltip tooltip;

        private void Awake()
        {
            Instance = this;
        }

        public static void ShowTooltip(string title, string description, string price)
        {
            Instance.tooltip.gameObject.SetActive(true);
            Instance.tooltip.SetTitleAndDescriptionText(title, description, price);
        }

        public static void HideTooltip()
        {
            Instance.tooltip.gameObject.SetActive(false);
        }
    }
}
