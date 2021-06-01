using System.Collections.Generic;
using UnityEngine;

namespace Field
{
    public class Grid
    {
        private Node[,] _nodes;

        private int _width;
        private int _height;

        private Vector2Int _startCoordinate;
        private Vector2Int _targetCoordinate;

        private Node _selectedNode;
        private FlowFieldPathfinding _pathfinding;

        public Grid(int width, int height, Vector3 offset, float nodeSize, Vector2Int start, Vector2Int target)
        {
            _width = width;
            _height = height;
            _startCoordinate = start;
            _targetCoordinate = target;

            _nodes = new Node[width, height];

            for (int i = 0; i < _nodes.GetLength(0); i++)
            {
                for (int j = 0; j < _nodes.GetLength(1); j++)
                {
                    _nodes[i, j] = new Node(offset + new Vector3(i + .5f,0,j+.5f) * nodeSize);
                }
            }

            _pathfinding = new FlowFieldPathfinding(this, target);
            _pathfinding.UpdateField();
        }

        public int Width { get => _width; }
        public int Height { get => _height; }

        public Node GetStartNode()
        {
            return GetNode(_startCoordinate);
        }
        public Node GetTargetNode()
        {
            return GetNode(_targetCoordinate);
        }

        public void SelectCoordinate(Vector2Int coordinate)
        {
            _selectedNode = GetNode(coordinate);
        }
        public void UnselectNode()
        {
            _selectedNode = null;
        }
        public bool HasSelectedNode()
        {
            return _selectedNode != null;
        }
        public Node GetSelectedNode()
        {
            return _selectedNode;
        }

        public Node GetNode(Vector2Int coordinate)
        {
            return GetNode(coordinate.x, coordinate.y);
        }

        public Node GetNode(int i, int j)
        {
            if (i < 0 || i >= _width)
                return null;
            if(j < 0 || j >= _height)
                return null;

            return _nodes[i, j];
        }

        public IEnumerable<Node> EnumerateAllNodes()
        {
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    yield return GetNode(i, j);
                }
            }
        }

        public void UpdatePathfinding()
        {
            _pathfinding.UpdateField();
        }
    }
}
