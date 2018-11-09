using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Samples.Common {
    [Serializable]
    public struct SpawnSpheres : ISharedComponentData {
        public GameObject prefab;
        public bool spawnLocal;
        public const float _PI = Mathf.PI;
        public int count;
        [HideInInspector] public float step;
        [HideInInspector] public float3 scale;
    }

    public class MySpawnerComponent : SharedComponentDataWrapper<SpawnSpheres> { }
}