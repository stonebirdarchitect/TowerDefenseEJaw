using System.Collections.Generic;
using Assets._scripts;
using UnityEngine;

namespace Assets.__scripts
{
      [CreateAssetMenu(fileName = "New Wave", menuName = "Enemy Wave")]
      public class EnemyWave : ScriptableObject
      {
            public List<EnemyClass> EnemyTypes;
            public List<int> Enemies;
            public int Duration;
      }
}
