using Enemy;
using UnityEngine;

namespace Turret.Weapon.Projectile.Bullet
{
    [CreateAssetMenu(menuName ="Assets/Bullet Projectile Asset", fileName ="BulletProjectile")]
    public class BulletProjectileAsset : ProjectileAssetBase
    {
        [SerializeField]
        private BulletProjectile _bulletProjectile;
        public override IProjectile CreateProjectile(Vector3 origin, Vector3 originForward, EnemyData enemyData)
        {
            return Instantiate(_bulletProjectile,origin,Quaternion.LookRotation(originForward, Vector3.up));
        }
    }
}
