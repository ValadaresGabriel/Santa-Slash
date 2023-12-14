using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class SpellDamageColliderManager : WeaponDamageColliderManager
    {
        private void OnEnable()
        {
            EnableDamageCollider();
        }

        private void OnDisable()
        {
            DisableDamageCollider();
        }
    }
}
