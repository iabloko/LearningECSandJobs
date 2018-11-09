using System;
using Unity.Entities;
using UnityEngine;

namespace Samples.Common {
    [Serializable]
    public struct SpawnRandomCircle : ISharedComponentData {
        public GameObject prefab;
        public bool spawnLocal;
        public float radius;
        public int count;
    }

    public class SpawnRandomCircleComponent : SharedComponentDataWrapper<SpawnRandomCircle> { }
}