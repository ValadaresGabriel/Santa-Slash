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

            if (!PlayerManager.Instance.IsInInteractionArea) return;

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

            // UIManager.Instance.shopManager.OpenShop(npc.npcShop.itemsToSell);

            if (npc.dialog != null)
            {
                UIManager.Interact(UI.Interaction.Dialog, npc: npc);
                return;
            }

            UIManager.Interact(UI.Interaction.Shop, items: npc.npcShop.itemsToSell);
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
                dialogueGameObject.SetActive(true);
        }
    }
}
