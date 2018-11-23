using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbits {
    [System.Serializable]
    public class Ellipse {
        public float xAxis;
        public float yAxis;

        public Ellipse (float xAxis, float yAxis) {
            this.xAxis = xAxis;
            this.yAxis = yAxis;
        }
        public Vector2 Evalute (float t) {
            float angle = Mathf.Deg2Rad * 360f * t;
            float x = Mathf.Sin (angle) * xAxis;
            float y = Mathf.Cos (angle) * yAxis;
            return new Vector2 (x, y);
        }
    }
}