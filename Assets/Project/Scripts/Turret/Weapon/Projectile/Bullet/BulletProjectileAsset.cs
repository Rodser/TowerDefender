using Enemy;
using UnityEngine;

namespace Turret.Weapon.Projectile.Bullet
{
    [CreateAssetMenu(menuName ="Assets/Bullet Projectile Asset", fileName ="BulletProjectile")]
    public class BulletProjectileAsset : ProjectileAssetBase
    {
        [SerializeField]
        private BulletProjectile _bulletProjectile;
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _damage;

        public float Speed { get => _speed; }
        public float Damage { get => _damage; }

        public override IProjectile CreateProjectile(Vector3 origin, Vector3 originForward, EnemyData enemyData)
        {
            BulletProjectile projectile = Instantiate(_bulletProjectile,origin,Quaternion.LookRotation(originForward, Vector3.up));
            projectile.SetAsset(this);
            return projectile;
        }
    }
}
