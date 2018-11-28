using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbits {
    [ExecuteInEditMode]
    public class OrbitLineRenderer : MonoBehaviour {
        [Range (3, 64)] public int points;
        public LineRenderer LineRenderer;
        [Range (1, 100)] public float radius = 1;

        private LinkedList<DynamicVertex> vertices;

        public class DynamicVertex {
            public Vector3 position;
            public Vector3 target;
            public float speed;

            public DynamicVertex (Vector3 valueVertex, Vector3 valueTarget, float valueSpeed) {
                this.position = valueVertex;
                this.target = valueTarget;
                this.speed = valueSpeed;
            }
        }
        void Awake () {
            LineRenderer.widthMultiplier = 0.1f;
            vertices = new LinkedList<DynamicVertex> ();
            vertices.AddLast (new DynamicVertex (Vector3.zero, Vector3.zero, 1));
            vertices.AddLast (new DynamicVertex (Vector3.zero, Vector3.zero, 1));
            vertices.AddLast (new DynamicVertex (Vector3.zero, Vector3.zero, 1));
        }

        void Update () {
            UpdateVertexList ();
            foreach (var vertex in vertices) {
                vertex.position = Vector3.Lerp (vertex.position, vertex.target, 3 * Time.deltaTime);
            }
            var renderList = new Vector3[vertices.Count + 2];
            int n = 0;
            foreach (var vert in vertices) {
                renderList[n++] = vert.position;
            }
            renderList[renderList.Length - 2] = renderList[0];
            renderList[renderList.Length - 1] = renderList[1];
            LineRenderer.positionCount = renderList.Length;
            LineRenderer.SetPositions (renderList);
        }

        private void UpdateVertexList () {
            int count = vertices.Count;
            int i = 0;
            foreach (var point in vertices) {
                float x = Mathf.Cos ((i / (float) points) * 2 * Mathf.PI);
                float z = Mathf.Sin ((i / (float) points) * 2 * Mathf.PI);
                //Vector2 pos = orbitpath.Evalute (points);
                point.target = new Vector3 (x, 0, z) * radius;
                i++;
            }

            for (i = count; i < points; ++i) {
                float x = Mathf.Cos ((i / (float) points) * 2 * Mathf.PI);
                float z = Mathf.Sin ((i / (float) points) * 2 * Mathf.PI);
                //Vector2 pos = orbitpath.Evalute (points);
                vertices.AddLast (new DynamicVertex (vertices.First.Value.position, new Vector3 (x, 0, z) * radius, vertices.First.Value.speed));
            }
            while (vertices.Count > points) {
                vertices.RemoveLast ();
            }
        }
    }
}