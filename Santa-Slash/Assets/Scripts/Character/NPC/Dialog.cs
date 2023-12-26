using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character.DialogSystem
{
    [System.Serializable]
    public struct DialogMessage
    {
        public string owner;

        [TextArea(3, 5)]
        public string message;
    }

    [CreateAssetMenu(fileName = "New Dialog", menuName = "Character/Dialog")]
    public class Dialog : ScriptableObject
    {
        public List<DialogMessage> initialDialogMessages;
        public List<DialogMessage> metDialogMessages;
        public bool hasMet;
    }
}
