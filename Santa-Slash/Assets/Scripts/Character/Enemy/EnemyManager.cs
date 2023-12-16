using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.AI;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class EnemyManager : CharacterManager
    {
        [Header("Settings")]
        public Enemy enemy;
        public LayerMask playerLayerMask;

        public EnemyAI EnemyAI { get; private set; }
        public EnemyLocomotion EnemyLocomotion { get; private set; }
        public Rigidbody2D Rb { get; private set; }
        public Animator Animator { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            health = GetComponent<EnemyHealth>();
            EnemyAI = GetComponent<EnemyAI>();
            EnemyLocomotion = GetComponent<EnemyLocomotion>();
            Rb = GetComponent<Rigidbody2D>();
            Animator = GetComponent<Animator>();
        }
    }
}
