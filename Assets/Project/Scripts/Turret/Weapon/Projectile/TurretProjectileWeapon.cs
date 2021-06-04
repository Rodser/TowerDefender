using Enemy;
using JetBrains.Annotations;
using Runtime;
using System.Collections.Generic;
using UnityEngine;

namespace Turret.Weapon.Projectile
{
    public class TurretProjectileWeapon : ITurretWeapon
    {
        private TurretProjectileWeaponAsset _asset;
        private TurretView _view;
        [CanBeNull]
        private EnemyData _closestEnemyData;
        private List<IProjectile> _projectiles = new List<IProjectile>();
        private float _timeBetweenShots;
        private float _maxDistance;
        private float _lastShotTime = 0f;

        public TurretProjectileWeapon(TurretProjectileWeaponAsset asset, TurretView view)
        {
            _asset = asset;
            _view = view;
            _timeBetweenShots = 1f / _asset.RateOfFire;
            _maxDistance = _asset.MaxDistance;
        }

        public void TickShoot()
        {
            TickWeapon();
            TickTower();
            TickProjectiles();
        }
        private void TickWeapon()
        {
            float passedTime = Time.time - _lastShotTime;
            if (passedTime < _timeBetweenShots)
                return;

            _closestEnemyData = Game.Player.EnemySearch.GetClosestEnemy(_view.transform.position, _maxDistance);
            if (_closestEnemyData == null)
                return;

            TickTower();

            Shoot(_closestEnemyData);
            _lastShotTime = Time.time;
        }
        private void TickTower()
        {
            if (_closestEnemyData != null && !_closestEnemyData.IsDead)
            {
                _view.TowerLookAt(_closestEnemyData.View.transform.position);
            }
        }
        private void TickProjectiles()
        {
            for (int i = 0; i < _projectiles.Count; i++)
            {
                IProjectile projectile = _projectiles[i];
                projectile.TickApproaching();
                if (projectile.DidHit())
                {
                    projectile.DestroyProjectile();
                    _projectiles[i] = null;
                }
            }

            _projectiles.RemoveAll(projectile => projectile == null);
        }

        private void Shoot(EnemyData enemyData)
        {
            _projectiles.Add(_asset.ProjectileAsset.CreateProjectile(_view.ProjectileOrigin.position,_view.ProjectileOrigin.forward,enemyData));
            _view.AnimateShot();
        }

    }
}
