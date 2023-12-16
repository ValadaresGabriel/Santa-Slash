using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Items;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class PlayerAttackManager : MonoBehaviour
    {
        [SerializeField] PlayerManager playerManager;
        private readonly Dictionary<WeaponType, IWeapon> weapons = new()
        {
            { WeaponType.Knife, new Knife() },
            { WeaponType.Staff, new Staff() },
        };

        public void RequestAttack()
        {
            IWeapon weapon = weapons[playerManager.characterWeaponManager.equippedWeapon.weaponType];
            weapon.AttemptToPerformAttack(playerManager.characterWeaponManager);
        }
    }
}
