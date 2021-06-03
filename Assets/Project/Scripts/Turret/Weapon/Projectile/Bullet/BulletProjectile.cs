﻿using Enemy;
using UnityEngine;

namespace Turret.Weapon.Projectile.Bullet
{
    public class BulletProjectile : MonoBehaviour, IProjectile
    {
        [SerializeField]
        private float _speed;
        private int _damage = 10;
        private bool _didHit = false;
        private EnemyData _hitEnemy = null;
        
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
            if(_hitEnemy != null)
            {
                _hitEnemy.GetDamage(_damage);
            }
            Destroy(gameObject);
        }

    }
}