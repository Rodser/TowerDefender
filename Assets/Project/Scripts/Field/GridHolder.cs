using UnityEngine;

namespace Field
{
    public class GridHolder : MonoBehaviour
    {
        [SerializeField]
        private int _gridWidth;
        [SerializeField]
        private int _gridHeight;
        [SerializeField]
        private float _nodeSize;
        [SerializeField]
        private Vector2Int _targetCoordinate;
        [SerializeField]
        private Vector2Int _startCoordinate;

        private Grid _grid;
        private Camera _camera;
        private Vector3 _offset;

        public Vector2Int StartCoordinate { get => _startCoordinate; }
        public Grid Grid { get => _grid; }

        private void Start()
        {
            _camera = Camera.main;

            // Default plane size is 10 by 10
            float width = _gridWidth * _nodeSize ;
            float height = _gridHeight * _nodeSize;
            transform.localScale = new Vector3(width * 0.1f, 1f, height * 0.1f);

            _offset = transform.position - (new Vector3(width, 0f, height) * 0.5f);
            _grid = new Grid(_gridWidth, _gridHeight, _offset, _nodeSize, _targetCoordinate);
        }

        private void Update()
        {
            if (_grid == null && _camera == null)
                return;
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = _camera.ScreenPointToRay(mousePosition);
            if(Physics.Raycast(ray,out RaycastHit hit))
            {
                if (hit.transform != transform) 
                    return;

                Vector3 hitPosition = hit.point;
                Vector3 difference = hitPosition - _offset;
                int x = (int)(difference.x / _nodeSize);
                int y = (int)(difference.z / _nodeSize);

                if (Input.GetMouseButtonDown(0))
                {
                    Node node = _grid.GetNode(x, y);
                    node.IsOccupied = !node.IsOccupied;
                    _grid.UpdatePathfinding();
                }
            }
        }

        private void OnValidate()
        {
            float width = _gridWidth * _nodeSize;
            float height = _gridHeight * _nodeSize;
            transform.localScale = new Vector3(width * 0.1f, 1f, height * 0.1f);
            _offset = transform.position - (new Vector3(width, 0f, height) * 0.5f);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_offset, 0.1f);

            if (_grid == null)
                return;
            foreach (Node node in _grid.EnumerateAllNodes())
            {
                if (node.NextNode == null)
                    continue;
                if (node.IsOccupied)
                {
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawCube(node.Position, new Vector3(1,1,1));
                    continue;
                }

                Gizmos.color = Color.red;
                Vector3 start = node.Position;
                Vector3 end = node.NextNode.Position;
                Vector3 dir = (end - start);
                start -= dir * 0.25f;
                end -= dir * 0.75f;

                Gizmos.DrawLine(start, end);
                Gizmos.DrawSphere(end, 0.1f);
            }
        }
    }
}
