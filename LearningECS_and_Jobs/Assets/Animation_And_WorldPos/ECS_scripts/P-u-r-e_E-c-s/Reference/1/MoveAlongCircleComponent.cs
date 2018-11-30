using System;
using Unity.Entities;
using Unity.Mathematics;

namespace Samples.Common {
    [Serializable]
    public struct MoveAlongCircle : IComponentData {
        public float3 center;
        public float radius;
        [NonSerialized]
        public float t;
    }

    [UnityEngine.DisallowMultipleComponent]
    public class MoveAlongCircleComponent : ComponentDataWrapper<MoveAlongCircle> { }
}