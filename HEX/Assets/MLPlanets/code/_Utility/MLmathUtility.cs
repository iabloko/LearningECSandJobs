using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace MLplanets {
    public struct MLgeneratePoints {
        static public void MLrandomGenerate (float3 center, ref NativeArray<float3> points) {
            int radius = 4;
            var radiusSquared = radius * radius;
            var count = points.Length;
            for (int i = 0; i < count; i++) {
                float angle = UnityEngine.Random.Range (0.0f, Mathf.PI * 2.0f);
                points[i] = center + new float3 {
                    x = math.sin (angle) * radius - (UnityEngine.Random.Range (-radius, radius)),
                    y = 0,
                    z = math.cos (angle) * radius - (UnityEngine.Random.Range (-radius, radius))
                };
            }
        }
        static public void MLRandomSolarSystem (float3 CenterMass, int radius, ref NativeArray<float3> points) {
            var diametr = 2 * radius;
            var count = points.Length;
            float angle = 270;
            float s = math.sin (angle) * radius;
            float ss = math.cos (angle) * radius;
            for (int i = 0; i < count; i++) {
                points[i] = CenterMass + new float3 {
                    x = s,
                    y = 0,
                    z = ss
                };
            }
        }
    }
}