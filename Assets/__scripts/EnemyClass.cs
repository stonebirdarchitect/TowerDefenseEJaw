using System.Collections.Generic;
using UnityEngine;

namespace Assets._scripts
{

      [CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
      public class EnemyClass : ScriptableObject
      {
            public int Health;
            public float MovementSpeed;
            public int Damage;
            public int RewardLow;
            public int RewardHigh;
            public GameObject Prefab;
      }
}
