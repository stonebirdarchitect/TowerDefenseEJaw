using System.Collections;
using System.Collections.Generic;
using Assets.__scripts;
using UnityEngine;

public class Spawner : MonoBehaviour
{
      public Transform Spawn;


      private float _countdown = 2;
      private float _delayBetweenEnemies = .5f;
      private int _currentWave = 0;

      public List<EnemyWave> Waves;

      void Update()
      {
            if (_countdown <= 0f && _currentWave != 6)
            {
                  StartCoroutine(SpawnEnemies());
            }

            _countdown -= Time.deltaTime;
      }

      IEnumerator SpawnEnemies()
      {
            GameManager.GameStat_CurrentWave = _currentWave + 1;

            _countdown = Waves[_currentWave].Duration;
            for (var s = 0; s < Waves[_currentWave].EnemyTypes.Count; s++)
            {
                  var ec = Waves[_currentWave].EnemyTypes[s];
                  for (var i = 0; i < Waves[_currentWave].Enemies[s]; i++)
                  {
                        var enemy = Instantiate(ec.Prefab, Spawn.position, Spawn.rotation);
                        enemy.GetComponent<Enemy>().SetValues(ec);
                        yield return new WaitForSeconds(_delayBetweenEnemies);
                  }
                  yield return new WaitForSeconds(_delayBetweenEnemies);
            }
            _currentWave++;
      }
}
