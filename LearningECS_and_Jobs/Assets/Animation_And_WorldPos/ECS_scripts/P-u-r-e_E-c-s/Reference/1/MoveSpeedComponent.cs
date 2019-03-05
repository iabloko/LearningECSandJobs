using System;
using Unity.Entities;
namespace Samples.Common {
    [Serializable]
    public struct MoveSpeed : IComponentData {
        public float speed;
    }

    [UnityEngine.DisallowMultipleComponent]
    public class MoveSpeedComponent : ComponentDataProxy<MoveSpeed> { }
}