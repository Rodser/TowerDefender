using Field;
using UnityEngine;

namespace Unit
{
    class GridMovementAgent : MonoBehaviour
    {
        private const float TOLERANCE = 0.1f;
        [SerializeField]
        private float _speed;

        private Node _targetNode;

        private void Update()
        {
            if (_targetNode == null)
                return;
            Vector3 target = _targetNode.Position;
            float distancec = (target - transform.position).magnitude;

            if (distancec < TOLERANCE)
            {
                _targetNode = _targetNode.NextNode;
                return;
            }

            var dir = (target - transform.position).normalized;
            var delta = dir * (_speed * Time.deltaTime);
            transform.Translate(delta);
        }

        public void SetStartNode(Node node)
        {
            _targetNode = node;
        }
    }
}
