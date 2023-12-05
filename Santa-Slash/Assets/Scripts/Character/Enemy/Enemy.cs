using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio.Character
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "Character/Enemy")]
    public class Enemy : ScriptableObject
    {
        public int ID;
        public int maxHealth = 2;
        public int damage = 1;
        public float speed = 3;
        public float attackCooldown = 1;
        public float attackRange = 0.5f;
    }
}
