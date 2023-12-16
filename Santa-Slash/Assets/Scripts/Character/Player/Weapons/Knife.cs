using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;

namespace TranscendenceStudio.Items
{
    public class Knife : IWeapon
    {
        public void AttemptToPerformAttack(PlayerWeaponManager characterWeaponManager)
        {
            if (characterWeaponManager == null)
            {
                Debug.LogError("Character Weapon Manager is NULL!");
                return;
            }

            Vector3 difference = PlayerInputManager.Instance.GetMousePositionValue() - (Vector2)characterWeaponManager.transform.position;
            float distance = difference.magnitude;

            Vector2 direction = difference / distance;
            direction.Normalize();

            PerformAttack(characterWeaponManager, direction);
        }

        public void PerformAttack(PlayerWeaponManager characterWeaponManager, Vector2 direction)
        {
            GameObject weapon = ThrowableKnifePoolingManager.Instance.GetObject();

            weapon.transform.SetPositionAndRotation(characterWeaponManager.transform.position, characterWeaponManager.transform.rotation);
            weapon.GetComponent<Rigidbody2D>().velocity = direction * 10f;
        }

        // Attempt To Perform Ability
        // Perform Ability
    }
}
