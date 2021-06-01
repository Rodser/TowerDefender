using Field;
using UnityEngine;

namespace Enemy
{
    public class GridMovementAgent : IMovementAgent
    {
        private const float TOLERANCE = 0.1f;

        private float _speed;
        private Transform _transform;

        private Node _targetNode;

        public GridMovementAgent(float speed, Transform transform, GridField grid)
        {
            _speed = speed;
            _transform = transform;

            SetTargetNode(grid.GetStartNode());
        }

        public void TickMovement()
        {
            if (_targetNode == null)
                return;
            Vector3 target = _targetNode.Position;
            float distancec = (target - _transform.position).magnitude;

            if (distancec < TOLERANCE)
            {
                _targetNode = _targetNode.NextNode;
                return;
            }

            var dir = (target - _transform.position).normalized;
            var delta = dir * (_speed * Time.deltaTime);
            _transform.Translate(delta);
        }

        private void SetTargetNode(Node node)
        {
            _targetNode = node;
        }

    }
}
