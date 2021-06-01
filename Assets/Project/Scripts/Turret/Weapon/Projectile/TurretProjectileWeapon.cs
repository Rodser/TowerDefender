using Enemy;
using Runtime;
using UnityEngine;

namespace Turret.Weapon.Projectile
{
    public class TurretProjectileWeapon : ITurretWeapon
    {
        private TurretProjectileWeaponAsset _asset;
        private TurretView _view;
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
            float passedTime = Time.time - _lastShotTime;
            if (passedTime < _timeBetweenShots)
                return;

            EnemyData closestEnemyData = 
                Game.Player.EnemySearch.GetClosestEnemy(_view.transform.position, _maxDistance);
            if (closestEnemyData == null)
                return;

            Shoot(closestEnemyData);
            _lastShotTime = Time.time;
        }

        private void Shoot(EnemyData enemyData)
        {
            _asset.ProjectileAsset.CreateProjectile(_view.ProjectileOrigin.position,_view.ProjectileOrigin.forward,enemyData);
        }

    }
}
