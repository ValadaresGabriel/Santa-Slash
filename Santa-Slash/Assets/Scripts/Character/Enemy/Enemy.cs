using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "Character/Enemy")]
    public class Enemy : ScriptableObject
    {
        [Header("ID")]
        public int ID;

        [Header("Stats")]
        public int maxHealth = 2;
        public int damage = 1;
        public float speed = 3;

        [Header("Attack & AI")]
        public float attackCooldown = 1;
        public float attackRange = 0.5f;
        public float chasePlayerArea = 3;
        public float sleepAfterAttackTime = 0.5f;
    }
}
