using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;

namespace TranscendenceStudio.Items
{
    public interface IWeapon
    {
        void AttemptToPerformAttack(PlayerWeaponManager characterWeaponManager);

        void PerformAttack(PlayerWeaponManager characterWeaponManager, Vector2 direction);
    }
}
