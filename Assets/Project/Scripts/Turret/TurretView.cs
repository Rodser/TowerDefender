using UnityEngine;

namespace Turret
{
    public class TurretView : MonoBehaviour
    {
        private TurretData _data;

        public TurretData Data { get => _data; }

        internal void AttachData(TurretData turretData)
        {
            _data = turretData;
            transform.position = _data.Node.Position;
        }
    }
}
