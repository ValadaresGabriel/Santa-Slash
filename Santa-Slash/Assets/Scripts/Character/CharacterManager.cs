using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class CharacterManager : MonoBehaviour
    {
        public bool isAttacking = false;

        public bool IsAttacking
        {
            get => isAttacking;
            set => isAttacking = value;
        }
    }
}
