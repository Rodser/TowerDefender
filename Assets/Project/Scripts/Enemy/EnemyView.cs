using Field;
using UI.InGame.Overtips;
using UnityEngine;

namespace Enemy
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField]
        private EnemyOvertip _overtip;
        private EnemyData _data;
        private IMovementAgent _movementAgent;

        public EnemyData Data { get => _data; }
        public IMovementAgent MovementAgent { get => _movementAgent; }

        public void AttachData(EnemyData data)
        {
            _data = data;
            _overtip.SetData(_data);
        }

        public void CreatMovementAgent(GridField grid)
        {
            _movementAgent = new GridMovementAgent(Data.Asset.Speed, transform, grid);
        }

        internal void Die()
        {
            Destroy(gameObject);
        }

        internal void ReachedTarget()
        {
            Destroy(gameObject);
        }
    }
}
