using System.Collections.Generic;
using UnityEngine;

public class CheckpointsScript : MonoBehaviour
{
      public static List<Transform> CheckpointsList;

      void Awake()
      {
            CheckpointsList = new List<Transform>();

            for (var i = 0; i < transform.childCount; i++)
            {
                  CheckpointsList.Add(transform.GetChild(i));
            }
      }
}
