using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;

namespace TranscendenceStudio.Items
{
    public interface IWeapon
    {
        void AttemptToPerformAttack(CharacterWeaponManager characterWeaponManager);

        void PerformAttack(CharacterWeaponManager characterWeaponManager, Vector2 direction);
    }
}
