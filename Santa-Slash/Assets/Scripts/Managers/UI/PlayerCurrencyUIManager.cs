using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TranscendenceStudio.UI
{
    public class PlayerCurrencyUIManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI currencyText;

        public void SetCurrency(int currency)
        {
            currencyText.SetText(currency.ToString());
        }
    }
}
