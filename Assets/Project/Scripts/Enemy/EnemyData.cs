
using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyData
    {
        private EnemyView _view;
        private int _health;

        public EnemyData(EnemyAsset enemy)
        {
            _health = enemy.StartHealth;
        }

        public EnemyView View { get => _view; }

        public void AttachView(EnemyView view)
        {
            _view = view;
            _view.AttachData(this);
        }

        public void GetDamage(int damage)
        {
            _health -= damage;
            if(_health <= 0)
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
