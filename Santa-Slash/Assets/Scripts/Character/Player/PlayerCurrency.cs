using System.Collections;
using System.Collections.Generic;
// using TranscendenceStudio.UI;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class PlayerCurrency : MonoBehaviour
    {
        [SerializeField] int currency = 100;

        private void Start()
        {
            // PlayerUIManager.SetCurrency(currency);
        }

        public int Currency
        {
            get => currency;

            set
            {
                currency = value;
                // PlayerUIManager.SetCurrency(currency);
            }
        }
    }
}
