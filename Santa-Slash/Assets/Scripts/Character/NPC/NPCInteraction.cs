using System.Collections;
using System.Collections.Generic;
// using TranscendenceStudio.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TranscendenceStudio.Character
{
    public class NPCInteraction : Interaction
    {
        [SerializeField] GameObject dialogueGameObject;
        private NPC npc;

        private void Awake()
        {
            npc = GetComponent<NPCManager>().npc;

            if (npc == null)
            {
                Debug.LogError("The NPC does not have a NPC in the NPC Manager!");
            }
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);

            if (!isInTheInteractionArea) return;

            if (npc == null)
            {
                Debug.LogError($"The NPC does not have a NPC in the NPC Manager! NPC GameObject: {gameObject.name}");
                return;
            }

            if (PlayerManager.Instance.IsInteracting)
            {
                Debug.LogWarning("The Player is alredy interacting!");
                return;
            }

            // UIManager.Interact(UI.Interaction.Dialog, npc: npc);
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);

            if (other.transform.CompareTag("Player"))
                dialogueGameObject.SetActive(true);
        }

        protected override void OnTriggerExit2D(Collider2D other)
        {
            base.OnTriggerExit2D(other);

            if (other.transform.CompareTag("Player"))
                dialogueGameObject.SetActive(true);
        }
    }
}
