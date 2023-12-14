using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;

namespace TranscendenceStudio.Items
{
    public class Knife : IWeapon
    {
        public void AttemptToPerformAttack(CharacterWeaponManager characterWeaponManager)
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

        public void PerformAttack(CharacterWeaponManager characterWeaponManager, Vector2 direction)
        {
            GameObject weapon = ThrowableKnifePoolingManager.Instance.GetObject();

            Vector3 rotationZ = (Vector2)weapon.transform.position - PlayerInputManager.Instance.GetMousePositionValue();
            float rotation = Mathf.Atan2(rotationZ.y, rotationZ.x) * Mathf.Rad2Deg;

            weapon.transform.SetPositionAndRotation(characterWeaponManager.transform.position, Quaternion.Euler(0, 0, rotation + 80f));
            weapon.GetComponent<Rigidbody2D>().velocity = direction * 10f;
        }

        // Attempt To Perform Ability
        // Perform Ability
    }
}
