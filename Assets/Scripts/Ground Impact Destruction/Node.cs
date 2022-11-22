using UnityEngine;

namespace GroundImpactDestruction
{
    public class Node
    {
        public int id;
        public Vector2 topLeft;
        public Vector2 bottomLeft;
        public Vector2 bottomRight;
        public Vector2 topRight;

        public Node(Vector2[] nodes)
        {
            topLeft = nodes[0];
            bottomLeft = nodes[1];
            bottomRight = nodes[2];
            topRight = nodes[3];
        }

        public Node() { }

        public override string ToString()
        {
            return "id: " + id + "\n\ttop left: " + topLeft + "\ttop right: " + topRight + "\tbottom left: " + bottomLeft;
        }
    }
}
