using UnityEngine;

namespace Turret
{
    public class TurretView : MonoBehaviour
    {
        private TurretData _data;
        private Transform _projectileOrigin;

        public TurretData Data { get => _data; }
        public Transform ProjectileOrigin { get => _projectileOrigin; }

        internal void AttachData(TurretData turretData)
        {
            _data = turretData;
            transform.position = _data.Node.Position;
        }
    }
}
