using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TranscendenceStudio.Character
{
    public class NPCInteraction : Interaction
    {
        [SerializeField] GameObject dialogueGameObject;
        private NPCManager npcManager;
        private NPC npc;

        private void Awake()
        {
            npcManager = GetComponentInParent<NPCManager>();
            npc = npcManager.npc;

            if (npc == null)
            {
                Debug.LogError("The NPC does not have a NPC in the NPC Manager!");
                return;
            }
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);

            if (npc == null)
            {
                Debug.LogError($"The NPC does not have a NPC in the NPC Manager! NPC GameObject: {gameObject.name}");
                return;
            }

            // Play NPC's Hi feedback
            npcManager.PlayHiFeedback();

            if (npc.dialog != null)
            {
                Debug.Log("Enter Dialog");
                UIManager.Interact(UI.Interaction.Dialog, npcManager: npcManager);
                return;
            }

            if (npc.hasShop)
            {
                UIManager.Interact(UI.Interaction.Shop, npcManager: npcManager);
            }
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);

            if (dialogueGameObject == null) return;

            if (other.transform.CompareTag("Player"))
                dialogueGameObject.SetActive(true);
        }

        protected override void OnTriggerExit2D(Collider2D other)
        {
            base.OnTriggerExit2D(other);

            if (dialogueGameObject == null) return;

            if (other.transform.CompareTag("Player"))
                dialogueGameObject.SetActive(false);
        }
    }
}
