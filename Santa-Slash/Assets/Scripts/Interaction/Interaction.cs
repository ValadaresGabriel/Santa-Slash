using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TranscendenceStudio
{
    public class Interaction : MonoBehaviour, IPointerClickHandler
    {
        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (!PlayerManager.Instance.IsInInteractionArea)
            {
                Debug.Log("Is not in interaction area");
                return;
            }

            if (!PlayerManager.Instance.IsMouseOnInteractableObject)
            {
                Debug.Log("Mouse is not on Interactable Object");
                return;
            }

            if (PlayerManager.Instance.IsInteracting)
            {
                Debug.LogWarning("The Player is alredy interacting!");
                return;
            }
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                PlayerManager.Instance.IsInInteractionArea = true;
            }
        }

        protected virtual void OnTriggerExit2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                PlayerManager.Instance.IsInInteractionArea = false;
            }
        }
    }
}
