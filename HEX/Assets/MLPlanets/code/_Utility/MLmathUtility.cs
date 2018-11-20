using Unity.Collections;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace MLplanets {
    public struct MLgeneratePoints {
        static public void MLrandomGenerate (float3 center, ref NativeArray<float3> points) {
            int radius = 4;
            var radiusSquared = radius * radius;
            var count = points.Length;

            for (int i = 0; i < count; i++) {
                // Debug.Log("Test");
                float angle = UnityEngine.Random.Range (0.0f, Mathf.PI * 2.0f);
                points[i] = center + new float3 {
                    x = math.sin (angle),
                    y = math.sin (angle),
                    z = 0
                };
            }
        }
        static public void MLTryToSin (float3 center, ref NativeArray<float3> points) {
            var count = points.Length;
            float step = 1;

            for (int i = 0; i < count; i++) {
                points[i] = new float3 {
                    x = (i + 0.5f) * step - 1f,
                    y = 0f,
                    z = 0f
                };
            }
        }
    }
}