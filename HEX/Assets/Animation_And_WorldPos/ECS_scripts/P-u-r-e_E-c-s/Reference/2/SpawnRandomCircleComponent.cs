using System;
using Unity.Entities;
using UnityEngine;

namespace Samples.Common {
    /// <summary>
    /// Spawn count Entities based on the specified Prefab. Components on the Prefab will be added to the Entities.
    /// The PositionComponent of each Entity will be set to a random position on the circle described by
    /// the PositionComponent associated with this component and the radius.
    /// </summary>
    [Serializable]
    public struct SpawnRandomCircle : ISharedComponentData {
        public GameObject prefab;
        public bool spawnLocal;
        [Range (1, 100)] public float radius;
        [Range (1, 5000)] public int count;
    }

    public class SpawnRandomCircleComponent : SharedComponentDataWrapper<SpawnRandomCircle> { }
}