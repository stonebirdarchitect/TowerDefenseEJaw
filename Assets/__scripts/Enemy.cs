using Assets._scripts;
using UnityEngine;

public class Enemy : MonoBehaviour
{
      public static System.Random Random = new System.Random();
      public int CurrentCheckpoint = 0;
      public float Speed;
      public int Health;
      public int Damage;
      public int RewardLow;
      public int RewardHigh;

      private Transform _target;

      void Start()
      {
            _target = CheckpointsScript.CheckpointsList[0];
      }

      void Update()
      {
            Vector3 direction = _target.position - transform.position;
            transform.Translate(direction.normalized * Speed * Time.deltaTime, Space.World);

            if (DistanceToNext <= 0.1f)
            {
                  if (CurrentCheckpoint == CheckpointsScript.CheckpointsList.Count - 1)
                  {
                        GameManager.GameStat_Health -= Damage;
                        Destroy(gameObject);
                        return;
                  }

                  CurrentCheckpoint++;
                  _target = CheckpointsScript.CheckpointsList[CurrentCheckpoint];
            }

            if (Health <= 0)
            {
                  GameManager.GameStat_Money += RewardLow + Random.Next(RewardHigh - RewardLow);
                  Destroy(gameObject);
            }
      }

      public void SetValues(EnemyClass enemy)
      {
            Speed = enemy.MovementSpeed;
            Health = enemy.Health;
            Damage = enemy.Damage;
            RewardLow = enemy.RewardLow;
            RewardHigh = enemy.RewardHigh;
      }
      public float DistanceToNext => Vector3.Distance(transform.position, _target.position);
}
