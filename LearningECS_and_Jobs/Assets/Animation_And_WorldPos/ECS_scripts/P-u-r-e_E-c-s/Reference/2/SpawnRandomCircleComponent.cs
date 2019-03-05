using System;
using Unity.Entities;
using UnityEngine;

namespace Samples.Common {
    [Serializable]
    public struct SpawnRandomCircle : ISharedComponentData {
        public GameObject prefab;
        public bool spawnLocal;
        [Range (1, 100)] public float radius;
        [Range (1, 5000)] public int count;
    }

    public class SpawnRandomCircleComponent : SharedComponentDataProxy<SpawnRandomCircle> { }
}