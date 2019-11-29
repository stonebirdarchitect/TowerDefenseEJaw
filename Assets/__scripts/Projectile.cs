using UnityEngine;

public class Projectile : MonoBehaviour
{
      private Transform target;
      public float Speed = 50f;
      public int Damage;

      public void Seek(Transform _target)
      {
            target = _target;
      }

      void Update()
      {
            if (target == null)
            {
                  Destroy(gameObject);
                  return;
            }

            var direction = target.position - transform.position;
            var distanceCovered = Speed * Time.deltaTime;

            if (direction.magnitude <= distanceCovered)
            {
                  target.GetComponent<Enemy>().Health -= Damage;
                  Destroy(gameObject);
                  return;
            }
            transform.Translate(direction.normalized * distanceCovered, Space.World);
      }
}
