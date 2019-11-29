using System.Linq;
using Assets._scripts;
using UnityEngine;

public class Turret : MonoBehaviour
{

      public Transform Target;

      [Header("Attributes")]
      public float Range = 15f;
      public float Reload = .5f;
      public int Damage = 5;
      public int Level = 1;
      public int Type;

      [Header("Unity Setup Fields")]
      public float RotationSpeed = 10f;
      private float _fireReload = 0f;

      public GameObject Top;
      public GameObject Bottom;
      public GameObject BulletPrefab;
      public Transform exhaustPoint;

      void Start()
      {
            InvokeRepeating("GetTarget", 0f, 0.25f);
      }

      void Update()
      {
            if (Target == null)
            {
                  return;
            }

            Top.transform.rotation = Quaternion.Euler(0f, 
                                                      Quaternion.Lerp(Top.transform.rotation, 
                                                                      Quaternion.LookRotation(Target.position - transform.position), 
                                                                      Time.deltaTime * RotationSpeed).eulerAngles.y, 
                                                      0f);


            if (_fireReload <= 0f)
            {
                  Shoot();
                  _fireReload = Reload;
            }

            _fireReload -= Time.deltaTime;
      }



      private void Shoot()
      {
            var bullet = (GameObject) Instantiate(BulletPrefab, exhaustPoint.position, exhaustPoint.rotation);
            var projectile = bullet.GetComponent<Projectile>();
            Debug.Log("pr - " + projectile.Damage + "; dmg - " + Damage);
            projectile.Damage = Damage;
            Debug.Log("pr - " + projectile.Damage + "; dmg - " + Damage);
            if (projectile != null) projectile.Seek(Target);
      }


      public void GetTarget()
      {
            var enemies = GameObject.FindGameObjectsWithTag("enemy");
            var closest = enemies.Where(x => Vector3.Distance(x.transform.position, transform.position) <= Range);

            if (closest.Count() > 0)
            {
                  var leader = closest.Select(y => y.GetComponent<Enemy>().CurrentCheckpoint).Max();
                  closest = closest.Where(x => x.GetComponent<Enemy>().CurrentCheckpoint == leader);
                  Target = closest.First(x => x.GetComponent<Enemy>().DistanceToNext == closest.Select(y => y.GetComponent<Enemy>().DistanceToNext).Min()).transform;
            }
            else
            {
                  Target = null;
            }
      }

      void OnDrawGizmosSelected()
      {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Range);
      }

      public void GetValues(TurretClass turret, int type, int level)
      {
            Range = turret.Range[level];
            Reload = turret.Reload[level];
            Damage = turret.Damage[level];
            Level = level + 1;
            Type = type;
      }
}
