using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class PlayerHealth : Health, IHittable
    {
        public int GetWeaponDurabilityDamage()
        {
            return 0;
        }

        public void Hit(int damage, GameObject sender)
        {
            if (TakeDamage(damage))
            {
                Debug.Log("Took damage");
                return;
            }

            Debug.Log("Is Dead");
        }

        public Vector3 TargetPosition()
        {
            return transform.position;
        }
    }
}
