using System;
using Unity.Entities;
using UnityEngine;

namespace Math {
    [Serializable] public struct Count : IComponentData {
        [Range (25, 1000)] public float value;
    }
    public class CountComponent : ComponentDataProxy <Count> { }
}