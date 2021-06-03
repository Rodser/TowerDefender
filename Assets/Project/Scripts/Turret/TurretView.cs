using UnityEngine;

namespace Turret
{
    public class TurretView : MonoBehaviour
    {
        private TurretData _data;
        [SerializeField]
        private Transform _projectileOrigin;
        [SerializeField]
        private Transform _tower;
        [SerializeField]
        private Animator _animator;
        private static readonly int ShotAnimationIndex = Animator.StringToHash("Shot");

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

        public void AnimateShot()
        {
            _animator.SetTrigger(ShotAnimationIndex);
        }
    }
}
