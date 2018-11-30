using System;
using Unity.Entities;
using UnityEngine;
namespace MLplanets {
    [Serializable]
    public struct MLspawns : ISharedComponentData {
        public GameObject MLspawnGameObject;
        //[Range (1, 100)] public float radius; Нет радиуса, потому что он будет назначаться отдельно для каждого префаба
        [Range (1, 50000)] public int count;
    }
    public class MLspawnComponent : SharedComponentDataWrapper<MLspawns> { }
}