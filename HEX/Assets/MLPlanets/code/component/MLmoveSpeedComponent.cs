using System;
using Unity.Entities;
using UnityEngine;
namespace MLplanets {
    [Serializable]
    public struct MLmoveSpeed : IComponentData {
        public float MoveSpeed;
    }
    public class MLmoveSpeedComponent : ComponentDataWrapper<MLmoveSpeed> { 
        
    }
}