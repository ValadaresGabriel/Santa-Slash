using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class RangedAttackManager : MonoBehaviour
    {
        [SerializeField] CharacterWeaponManager characterWeaponManager;

        public void ThrowAttack()
        {
            if (characterWeaponManager == null)
            {
                Debug.LogError("Character Weapon Manager is NULL in RangedAttackManager!");
                return;
            }

            if (characterWeaponManager.equippedWeapon.isRangedWeapon)
            {
                Vector3 difference = PlayerInputManager.Instance.GetMousePositionValue() - (Vector2)characterWeaponManager.transform.position;
                float distance = difference.magnitude;

                Vector2 direction = difference / distance;
                direction.Normalize();


                ThrowWeapon(direction);
                return;
            }

            if (characterWeaponManager.equippedWeapon.isMagicWeapon)
            {
                CastSpell();
            }
        }

        private void ThrowWeapon(Vector2 direction)
        {
            GameObject weapon = ThrowableKnifePoolingManager.Instance.GetObject();

            Vector3 rotationZ = (Vector2)weapon.transform.position - PlayerInputManager.Instance.GetMousePositionValue();
            float rotation = Mathf.Atan2(rotationZ.y, rotationZ.x) * Mathf.Rad2Deg;

            weapon.transform.SetPositionAndRotation(characterWeaponManager.transform.position, Quaternion.Euler(0, 0, rotation + 80f));
            weapon.GetComponent<Rigidbody2D>().velocity = direction * 10f;
        }

        private void CastSpell()
        {
            GameObject skill = SkillsPoolingManager.Instance.GetObject();

            skill.transform.SetPositionAndRotation(characterWeaponManager.spellArea.transform.position, Quaternion.identity);
        }
    }
}
