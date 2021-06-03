
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


        public void AttachView(EnemyView view)
        {
            _view = view;
            _view.AttachData(this);
        }

        public void GetDamage(float damage)
        {
            _health -= damage;
            if(_health <= 0f)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("Die");
        }
    }
}
