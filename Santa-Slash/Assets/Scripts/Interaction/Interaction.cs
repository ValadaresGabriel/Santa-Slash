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
            if (!PlayerManager.Instance.IsInInteractionArea) return;
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
