using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Mynamespace {
    public struct GeneratePoints {
        static public void RandomPointsOnCircle (float3 center, float radius, ref NativeArray<float3> points) {
            var count = points.Length;
            for (int i = 0; i < count; i++) {
                float angle = UnityEngine.Random.Range (0.0f, Mathf.PI * 2.0f);
                points[i] = center + new float3 {
                    x = math.sin (angle) * radius,
                    y = 0,
                    z = math.cos (angle) * radius
                };
            }
        }
        static public void _awake (ref NativeArray<float3> points) {
            float t = Time.time;
            var count = points.Length;
            for (int i = 0; i < count; i++) {
                float angle = UnityEngine.Random.Range (0.0f, Mathf.PI * 2.0f);
                points[i] = new float3 {
                    x = 0,
                    y = 50 * math.sin (3.14f * i),
                    z = 0
                };
            }
        }
    }
}