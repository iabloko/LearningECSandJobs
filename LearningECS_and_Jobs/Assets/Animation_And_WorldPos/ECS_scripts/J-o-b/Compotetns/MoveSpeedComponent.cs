using System;
using Unity.Entities;
using UnityEngine;

namespace Math {
    [Serializable] public struct MoveSpeed : IComponentData {
        [Range (25, 1000)] public float value;
    }
    public class MoveSpeedComponent : ComponentDataWrapper<MoveSpeed> { }
}