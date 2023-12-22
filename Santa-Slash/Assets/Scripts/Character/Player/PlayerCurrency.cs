using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.UI;

// using TranscendenceStudio.UI;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class PlayerCurrency : MonoBehaviour
    {
        [SerializeField] int currency = 0;

        private void Start()
        {
            UIManager.Instance.playerUIManager.playerCurrencyUIManager.SetCurrency(0);
        }

        public int Currency
        {
            get => currency;
            set
            {
                currency = value;
                UIManager.Instance.playerUIManager.playerCurrencyUIManager.SetCurrency(currency);
            }
        }
    }
}
