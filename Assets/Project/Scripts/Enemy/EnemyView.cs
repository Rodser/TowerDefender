using UnityEngine;

namespace Enemy
{
    public class EnemyView : MonoBehaviour
    {
        private EnemyData _data;
        private IMovementAgent _movementAgent;

        public EnemyData Data { get => _data; }
        public IMovementAgent MovementAgent { get => _movementAgent; }

        public void AttachData(EnemyData data)
        {
            _data = data;
        }

        public void CreatMovementAgent(Field.Grid grid)
        {
            _movementAgent = new GridMovementAgent(5f, transform, grid);
        }
    }
}
