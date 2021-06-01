using Enemy;
using UnityEngine;

namespace Turret.Weapon.Projectile.Bullet
{
    public class BulletProjectile : MonoBehaviour, IProjectile
    {
        [SerializeField]
        private float _speed;
        private bool _didHit;
        private EnemyData _hitEnemy;
        
        public void TickApproaching()
        {
            transform.Translate(transform.forward * _speed * Time.deltaTime, Space.World);
        }
        private void OnTriggerEnter(Collider other)
        {
            _didHit = true;
            if (other.CompareTag("Enemy"))
            {
                EnemyView enemyView = other.GetComponent<EnemyView>();
                if (enemyView != null)
                {
                    _hitEnemy = enemyView.Data;
                }
            }
        }
        public bool DidHit()
        {
            return _didHit;
        }
        public void DestroyProjectile()
        {
            if(_hitEnemy!= null)
            {
                Debug.Log("hit");
            }
            Destroy(gameObject);
        }

    }
}
