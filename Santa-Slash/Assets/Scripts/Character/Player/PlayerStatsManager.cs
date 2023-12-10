using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class PlayerStatsManager : MonoBehaviour
    {
        [SerializeField] int health;
        [SerializeField] int stamina;

        public int Health
        {
            get => health;
            set => health = value;
        }

        public int Stamina
        {
            get => stamina;
            set => stamina = value;
        }
    }
}
