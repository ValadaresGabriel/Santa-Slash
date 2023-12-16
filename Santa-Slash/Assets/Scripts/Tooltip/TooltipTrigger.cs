using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ClothGravity.UI
{
    public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            GameObject hoveredGameObject = eventData.pointerEnter;

            if (hoveredGameObject != null)
            {
                // The use of Interface fits perfectly for Tooltip system, since a lot of things in the game CAN use it, not only items.
                if (TryGetComponent(out ITooltip tooltipComponent))
                {
                    string tooltipTitle = tooltipComponent.GetTooltipTitle();
                    string tooltipDescription = tooltipComponent.GetTooltipDescription();
                    string tooltipPrice = tooltipComponent.GetTooltipPrice();

                    if (string.IsNullOrEmpty(tooltipTitle) && string.IsNullOrEmpty(tooltipDescription) && string.IsNullOrEmpty(tooltipPrice))
                        return;

                    TooltipManager.ShowTooltip(tooltipTitle, tooltipDescription, tooltipPrice);
                }
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            TooltipManager.HideTooltip();
        }
    }
}
