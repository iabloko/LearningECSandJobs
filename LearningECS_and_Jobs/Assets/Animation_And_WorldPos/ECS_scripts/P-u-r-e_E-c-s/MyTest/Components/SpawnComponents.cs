using System;
using Unity.Entities;
using UnityEngine;
namespace Mynamespace {
    [Serializable]
    public struct SpawnCapsule : ISharedComponentData {
        public GameObject prefab;
        public bool spawnLocal;
        public int count;
    }
    public class SpawnComponents : SharedComponentDataWrapper<SpawnCapsule> { }
}