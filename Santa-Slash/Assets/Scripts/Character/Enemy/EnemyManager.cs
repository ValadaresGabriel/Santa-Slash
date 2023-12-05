using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    public class EnemyManager : CharacterManager
    {
        public Enemy enemy;
        public EnemyLocomotion enemyLocomotion { get; private set; }
        private Rigidbody2D rb;
        private Animator animator;

        protected override void Awake()
        {
            base.Awake();

            enemyLocomotion = GetComponent<EnemyLocomotion>();
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            health = GetComponent<EnemyHealth>();
        }
    }
}
