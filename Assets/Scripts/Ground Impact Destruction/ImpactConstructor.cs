using System.Collections.Generic;
using UnityEngine;

namespace GroundImpactDestruction
{
    public class ImpactConstructor
    {
        LinkedList<Node> nodes = new LinkedList<Node>();

        // points that create the borders of the square
        public Vector2 topLeft, topRight, bottomLeft, bottomRight;

        public ImpactConstructor(Node node)
        {
            topLeft = node.topLeft;
            bottomLeft = node.bottomLeft;
            bottomRight = node.bottomRight;
            topRight = node.topRight;
        }

        public override string ToString()
        {
            return "Number of nodes: " + nodes.Count.ToString();
        }

        public void InsertNode(Node newNode)
        {
            newNode.id = nodes.Count + 1;
            LinkedListNode<Node> node;

            if (nodes.Count >= 2)
            {
                node = nodes.First;
                foreach (Node _ in nodes)
                {
                    if (node.Next == null) // if the loop reach the last element, the node must be before the first of after the last
                    {
                        LinkedListNode<Node> first = nodes.First;
                        if (NewNodeIsBefore(first, newNode))
                        {
                            nodes.AddBefore(first, newNode);
                            return;
                        }

                        LinkedListNode<Node> last = nodes.Last;
                        if (NewNodeIsAfter(last, newNode))
                        {
                            nodes.AddAfter(last, newNode);
                            return;
                        }
                    }

                    // if new node is between the actual node and the next, add it between
                    if (NewNodeIsAfter(node, newNode) && NewNodeIsBefore(node.Next, newNode))
                    {
                        nodes.AddAfter(node, newNode);
                        return;
                    }

                    node = node.Next; // set to the next node
                }
            }
            else
            {
                if (nodes.Count == 0)
                    nodes.AddFirst(newNode); // if is the first one, add first
                else if (nodes.Count == 1) // if is the second one
                {
                    node = nodes.First;
                    if (NewNodeIsBefore(node, newNode)) // if is smaller than the first,
                        nodes.AddBefore(node, newNode); // add before him
                    else if (NewNodeIsAfter(node, newNode)) // if is bigger than the first
                        nodes.AddAfter(node, newNode); // add after him
                }
            }
        }

        private bool NewNodeIsBefore(LinkedListNode<Node> node, Node newNode)
        {
            return node.Value.topLeft.x >= newNode.topRight.x;
        }

        private bool NewNodeIsAfter(LinkedListNode<Node> node, Node newNode)
        {
            return node.Value.topRight.x <= newNode.topLeft.x;
        }

        public Vector2[] ToArray()
        {
            // return the linked list nodes as a array of vectors
            // start to the left to right

            List<Vector2> vectorList = new List<Vector2>();

            LinkedListNode<Node> node = nodes.First;

            foreach (Node _ in nodes)
            {
                Node value = node.Value;

                vectorList.Add(value.topLeft);
                vectorList.Add(value.bottomLeft);
                vectorList.Add(value.bottomRight);
                vectorList.Add(value.topRight);

                if (node.Next == null) return vectorList.ToArray();
                else node = node.Next;
            }

            return vectorList.ToArray();
        }

        public void ShowNodes()
        {
            int i = 1;
            Debug.Log("----- start list");
            foreach (Node node in nodes)
            {
                Debug.Log("\t--" + i);
                Debug.Log("\t" + node);
                i++;
            }
            Debug.Log("----- end list");
        }
    }
}