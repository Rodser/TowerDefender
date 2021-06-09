
using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyData
    {
        private EnemyView _view;
        private EnemyAsset _enemyAsset;
        private float _health;

        public EnemyData(EnemyAsset enemy)
        {
            _health = enemy.StartHealth;
            _enemyAsset = enemy;
        }

        public EnemyView View { get => _view; }
        public EnemyAsset Asset { get => _enemyAsset; }

        public bool IsDead => _health <= 0f;

        public float Health { get => _health; }

        public event Action<float> HealthChanged;
        public void AttachView(EnemyView view)
        {
            _view = view;
            _view.AttachData(this);
        }

        public void GetDamage(float damage)
        {
            if (IsDead)
                return;
                
            _health -= damage;
            if (_health < 0)
                _health = 0;
            HealthChanged?.Invoke(_health);
        }

        public void Die()
        {
            _view.Die();
        }
        public void ReachedTarget()
        {
            _health = 0;
            _view.ReachedTarget();
        }
    }
}
