using Assets._scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.__scripts
{
      public class Builder : MonoBehaviour
      {
            public static Builder Instance;

            public List<TurretClass> StandardTurrets;

            public TurretClass GetTurret(int i)
            {
                  Debug.Log(StandardTurrets.Count + " " + i);
                  return StandardTurrets[i];
            }

            public void Awake()
            {
                  if (Instance != null)
                  {
                        Debug.Log("More than one Build Manager");
                        return;
                  }
                  Instance = this;
            }
      }
}
