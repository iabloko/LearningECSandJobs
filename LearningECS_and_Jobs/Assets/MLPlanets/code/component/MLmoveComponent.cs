using System;
using Unity.Entities;
using Unity.Mathematics;

namespace MLplanets {
    [Serializable]
    public struct MLmove : IComponentData {
        [NonSerialized] public float t;
        public float speed;
        public float3 height;
    }

    [UnityEngine.DisallowMultipleComponent]
    public class MLmoveComponent : ComponentDataProxy<MLmove> { }
}