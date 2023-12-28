using UnityEngine;
using UnityEngine.EventSystems;

namespace TranscendenceStudio.Character
{
    public class InteractionMousePositionManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            PlayerManager.Instance.IsMouseOnInteractableObject = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            PlayerManager.Instance.IsMouseOnInteractableObject = false;
        }
    }
}
