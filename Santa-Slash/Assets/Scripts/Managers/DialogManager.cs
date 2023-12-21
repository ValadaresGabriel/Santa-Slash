using System.Collections;
using System.Collections.Generic;
using TMPro;
using TranscendenceStudio.UI;
using UnityEngine;

namespace TranscendenceStudio.Character.DialogSystem
{
    public class DialogManager : MonoBehaviour
    {
        [SerializeField] GameObject dialogGameObject;
        [SerializeField] TextMeshProUGUI ownerText;
        [SerializeField] TextMeshProUGUI messageText;
        [SerializeField] float letterDelayTime = 0.01f;
        [SerializeField] AudioClip[] dialogTypeSFX;
        private int dialogIndex = 0;
        private bool isTypingMessage = false;
        private NPC currentNPC;
        private Coroutine typeMessageCoroutine;
        private List<DialogMessage> dialogMessage = new();

        public void OpenDialog(NPC npc)
        {
            PlayerInputManager.Instance.NextDialogEvent += NextDialog;

            currentNPC = npc;

            dialogGameObject.SetActive(true);
            ConfigureDialog();
        }

        public void CloseDialog()
        {
            PlayerInputManager.Instance.NextDialogEvent -= NextDialog;

            dialogGameObject.SetActive(false);
            dialogIndex = 0;
            StopCoroutine(typeMessageCoroutine);
        }

        private void ConfigureDialog()
        {
            if (PlayerManager.Instance != null)
            {
                PlayerManager.Instance.IsOnShop = true;
            }
            else
            {
                Debug.LogError("Player Manager is Null!");
                return;
            }

            if (currentNPC.dialog == null)
            {
                Debug.Log("<color=yellow>The NPC does not have dialog!</color>");
            }

            ownerText.SetText(currentNPC.npcName);

            if (currentNPC.dialog.hasMet)
            {
                // Has met dialog
                dialogMessage = currentNPC.dialog.metDialogMessages;
                NextDialog();
                return;
            }

            dialogMessage = currentNPC.dialog.initialDialogMessages;

            // Changing directly the ScriptableObject, not an instance of it. It shouldn't be a problem in this project
            currentNPC.dialog.hasMet = true;

            NextDialog();
        }

        private void NextDialog()
        {
            if (dialogIndex >= dialogMessage.Count)
            {
                FinalizeDialog();
                return;
            }

            if (isTypingMessage)
            {
                isTypingMessage = false;
                StopCoroutine(typeMessageCoroutine);
                messageText.SetText(dialogMessage[dialogIndex - 1].message);
                return;
            }

            messageText.SetText("");
            typeMessageCoroutine = StartCoroutine(TypeMessage(dialogMessage[dialogIndex++].message));
        }

        private void FinalizeDialog()
        {
            UIManager.CloseDialog();

            if (currentNPC.hasShop)
            {
                UIManager.Interact(UI.Interaction.Shop, items: currentNPC.npcShop.itemsToSell);
            }

            currentNPC = null;
        }

        private IEnumerator TypeMessage(string message)
        {
            isTypingMessage = true;

            foreach (char letter in message.ToCharArray())
            {
                // AudioClip selectedDialogSFX = dialogTypeSFX[Random.Range(0, dialogTypeSFX.Length)];

                // AudioManager.Instance.PlayEffectsAudio(selectedDialogSFX);

                messageText.SetText(messageText.text + letter);
                yield return new WaitForSeconds(letterDelayTime);
            }

            isTypingMessage = false;
        }
    }
}
