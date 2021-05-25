using UnityEngine;
using System.Collections.Generic;

namespace Field
{
    public class FlowFieldPathfinding
    {
        private Grid _grid;
        private Vector2Int _target;

        public FlowFieldPathfinding(Grid grid, Vector2Int target)
        {
            _grid = grid;
            _target = target;
        }

        public void UpdateField()
        {
            foreach (Node node in _grid.EnumerateAllNodes())
            {
                node.ResetWeight();
            }

            Queue<Vector2Int> queue = new Queue<Vector2Int>();
            queue.Enqueue(_target);
            _grid.GetNode(_target).PathWeight = 0;

            while (queue.Count > 0)
            {
                Vector2Int current = queue.Dequeue();
                Node currentNode = _grid.GetNode(current);
                float weightToTarget = currentNode.PathWeight + 1;

                foreach (Vector2Int neighbour in GetNeighbours(current))
                {
                    Node neighbourNode = _grid.GetNode(neighbour);
                    if (weightToTarget < neighbourNode.PathWeight)
                    {
                        neighbourNode.NextNode = currentNode;
                        neighbourNode.PathWeight = weightToTarget;
                        queue.Enqueue(neighbour);
                    }
                }
            }
        }

        private IEnumerable<Vector2Int> GetNeighbours(Vector2Int coordinate)
        {
            Vector2Int rightCoordinate = coordinate + Vector2Int.right;
            Vector2Int leftCoordinate = coordinate + Vector2Int.left;
            Vector2Int upCoordinate = coordinate + Vector2Int.up;
            Vector2Int downCoordinate = coordinate + Vector2Int.down;

            bool hasRightNode = rightCoordinate.x < _grid.Width && !_grid.GetNode(rightCoordinate).IsOccupied;
            bool hasLeftNode = leftCoordinate.x >= 0 && !_grid.GetNode(leftCoordinate).IsOccupied;
            bool hasUpNode = upCoordinate.y < _grid.Height && !_grid.GetNode(upCoordinate).IsOccupied;
            bool hasDownNode = downCoordinate.y >= 0 && !_grid.GetNode(downCoordinate).IsOccupied;

            if (hasRightNode)
                yield return rightCoordinate;
            if (hasLeftNode)
                yield return leftCoordinate;
            if (hasUpNode)
                yield return upCoordinate;
            if (hasDownNode)
                yield return downCoordinate;
        }
    }
}
