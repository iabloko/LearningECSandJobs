using Unity.Entities;
using UnityEngine;

public struct GraphIComponent : IComponentData { 
    public int resolution;
    public Transform[] points;
 }
