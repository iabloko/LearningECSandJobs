using System;
using Unity.Entities;
using UnityEngine;

namespace Samples.Common {
    [Serializable]
    public struct SpawnSpheres : ISharedComponentData {
        public GameObject prefab;
        public bool spawnLocal;
        public const float _PI = Mathf.PI;
        public int count;
    }

    public class MySpawnerComponent : SharedComponentDataWrapper<SpawnSpheres> { }
}