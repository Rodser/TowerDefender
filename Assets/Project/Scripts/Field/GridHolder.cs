using UnityEngine;
using UnityEngine.EventSystems;

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

        private GridField _grid;
        private Camera _camera;
        private Vector3 _offset;

        public Vector2Int StartCoordinate { get => _startCoordinate; }
        public GridField Grid { get => _grid; }

        public void CreatGrid()
        {
            _camera = Camera.main;

            // Default plane size is 10 by 10
            float width = _gridWidth * _nodeSize ;
            float height = _gridHeight * _nodeSize;
            transform.localScale = new Vector3(width * 0.1f, 1f, height * 0.1f);

            _offset = transform.position - (new Vector3(width, 0f, height) * 0.5f);
            _grid = new GridField(_gridWidth, _gridHeight, _offset, _nodeSize,_startCoordinate, _targetCoordinate);
        }

        public void RaycastInGrid()
        {
            if (_grid == null && _camera == null)
                return;
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
                return;
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = _camera.ScreenPointToRay(mousePosition);
            if(Physics.Raycast(ray,out RaycastHit hit))
            {
                if (hit.transform != transform)
                {
                    _grid.UnselectNode();
                    return;
                }

                Vector3 hitPosition = hit.point;
                Vector3 difference = hitPosition - _offset;
                int x = (int)(difference.x / _nodeSize);
                int y = (int)(difference.z / _nodeSize);

                _grid.SelectCoordinate(new Vector2Int(x, y));

            }
            else
            {
                _grid.UnselectNode();
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
