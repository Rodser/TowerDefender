using UnityEngine;

namespace Turret
{
    public class TurretView : MonoBehaviour
    {
        private TurretData _data;
        private Transform _projectileOrigin;
        [SerializeField]
        private Transform _tower;

        public TurretData Data { get => _data; }
        public Transform ProjectileOrigin { get => _projectileOrigin; }

        internal void AttachData(TurretData turretData)
        {
            _data = turretData;
            transform.position = _data.Node.Position;
        }

        public void TowerLookAt(Vector3 point)
        {
            point.y = _tower.position.y;
            _tower.LookAt(point);
        }
    }
}
