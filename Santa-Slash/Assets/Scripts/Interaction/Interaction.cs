using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TranscendenceStudio
{
    public class Interaction : MonoBehaviour, IPointerClickHandler
    {
        protected bool isInTheInteractionArea = false;

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (!isInTheInteractionArea) return;
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                isInTheInteractionArea = true;
            }
        }

        protected virtual void OnTriggerExit2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                isInTheInteractionArea = false;
            }
        }
    }
}
