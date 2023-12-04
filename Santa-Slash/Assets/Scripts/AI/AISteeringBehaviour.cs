using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.AI
{
    public abstract class AISteeringBehaviour : MonoBehaviour
    {
        public abstract (float[] danger, float[] interest) GetSteering(float[] danger, float[] interest, AIData aiData);
    }
}
