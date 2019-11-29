using System.Collections.Generic;
using UnityEngine;

namespace Assets._scripts
{

      [CreateAssetMenu(fileName = "New Turret", menuName = "Turret")]
      public class TurretClass : ScriptableObject
      {
            public List<int> Price;
            public List<int> Range;
            public List<float> Reload;
            public List<int> Damage;
            public List<Material> Materials;
            public GameObject TurretPrefab;
      }
}
