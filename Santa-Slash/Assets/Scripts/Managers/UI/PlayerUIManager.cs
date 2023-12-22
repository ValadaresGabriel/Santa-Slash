using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.UI
{
    public class PlayerUIManager : MonoBehaviour
    {
        [Header("Stats")]
        public PlayerStatsUIManager playerStatsUIManager;

        [Header("Currency")]
        public PlayerCurrencyUIManager playerCurrencyUIManager;
    }
}
