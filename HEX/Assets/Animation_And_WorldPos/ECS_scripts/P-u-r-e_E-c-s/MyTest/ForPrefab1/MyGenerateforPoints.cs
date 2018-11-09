using Unity.Collections;
using Unity.Mathematics;

namespace Samples.Common {
    public struct MyGenerateforPoints {
        static public float3 SineFunction (float x, float z, float t) {
            float _PI = (float) math.PI;
            float3 _vector;
            _vector.x = x;
            _vector.y = math.sin (_PI * x + t);
            _vector.z = z;
            return _vector;
        }
    }
}