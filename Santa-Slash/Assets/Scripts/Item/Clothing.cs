using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Items
{
    [CreateAssetMenu(fileName = "New Clothing", menuName = "Items/Clothing")]
    public class Clothing : Item
    {
        public RuntimeAnimatorController animator;
    }
}
