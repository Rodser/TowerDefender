using UnityEngine;

namespace Field
{
    public class Node
    {
        public Node(Vector3 position)
        {
            Position = position;
        }

        public Vector3 Position { get; set; }
        public Node NextNode { get; set; }
        public bool IsOccupied { get; set; }
        public float PathWeight { get; set; }

        public void ResetWeight()
        {
            PathWeight = float.MaxValue;
        }
    }
}
