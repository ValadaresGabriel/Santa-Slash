using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.AI
{
    public abstract class AIDetector : MonoBehaviour
    {
        public abstract void Detect(AIData aiData);
    }

}