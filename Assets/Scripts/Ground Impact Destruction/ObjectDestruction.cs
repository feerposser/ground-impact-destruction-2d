using System.Collections.Generic;
using UnityEngine;

namespace GroundImpactDestruction
{
    public class ObjectDestruction : MonoBehaviour
    {
        public float deepness = .3f;

        PolygonCollider2D polygon;
        ImpactConstructor impactConstructor;
        List<Vector2> points = new List<Vector2>();

        void Start()
        {
            polygon = GetComponent<PolygonCollider2D>();

            points = GetOriginalPollygonColliderNodes();

            Vector2[] v1 = { points[0], points[1], points[2], points[3] };

            Node originalPoints = new Node(v1);

            impactConstructor = new ImpactConstructor(originalPoints);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            CreateImpact(collision.contacts[0].point, collision.contacts[1].point);

            Destroy(collision.gameObject);
        }

        List<Vector2> GetOriginalPollygonColliderNodes()
        {
            List<Vector2> p = new List<Vector2>();
            foreach (Vector2 vector in polygon.points) p.Add(vector);

            return p;
        }

        void CreateImpact(Vector2 topLeftImpact, Vector2 topRightImpact)
        {
            Vector2 topLeft = transform.InverseTransformPoint(topLeftImpact);
            Vector2 bottomLeft = transform.InverseTransformPoint(topLeftImpact) - new Vector3(0, deepness, 0);

            Vector2 bottomRight = transform.InverseTransformPoint(topRightImpact) - new Vector3(0, deepness, 0);
            Vector2 topRight = transform.InverseTransformPoint(topRightImpact);

            Vector2[] nodes = { topLeft, bottomLeft, bottomRight, topRight };

            Node hotspot = new Node(nodes);

            impactConstructor.InsertNode(hotspot);

            BuildPolygonPoints();

            impactConstructor.ShowNodes();

            return;
        }

        void BuildPolygonPoints()
        {
            points.Clear();

            points.Add(impactConstructor.topLeft);

            foreach (Vector2 node in impactConstructor.ToArray()) points.Add(node);

            points.Add(impactConstructor.topRight);
            points.Add(impactConstructor.bottomRight);
            points.Add(impactConstructor.bottomLeft);

            polygon.SetPath(0, points);
        }
    }
}