using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using UnityEngine;

namespace TranscendenceStudio
{
    public class GroundManager : MonoBehaviour
    {
        [SerializeField] float velocityMultiplier;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                PlayerManager.Instance.PlayerLocomotion.ApplyMovementSpeedMultiplier(velocityMultiplier);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                PlayerManager.Instance.PlayerLocomotion.ApplyMovementSpeedMultiplier(1);
            }
        }
    }
}
