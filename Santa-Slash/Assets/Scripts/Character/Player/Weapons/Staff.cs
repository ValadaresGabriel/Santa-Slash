using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;

namespace TranscendenceStudio.Items
{
    public class Staff : IWeapon
    {
        public void AttemptToPerformAttack(PlayerWeaponManager characterWeaponManager)
        {
            if (characterWeaponManager == null)
            {
                Debug.LogError("Character Weapon Manager is NULL!");
                return;
            }

            Vector2 positionToCastSpell = characterWeaponManager.spellArea.transform.position;

            PerformAttack(characterWeaponManager, positionToCastSpell);
        }

        public void PerformAttack(PlayerWeaponManager characterWeaponManager, Vector2 positionToCastSpell)
        {
            GameObject spell = StaffSpellPoolingManager.Instance.GetObject();

            spell.transform.SetPositionAndRotation(positionToCastSpell, Quaternion.identity);
        }

        // Attempt To Perform Ability
        // Perform Ability
    }
}
