using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace TestECS {
    public class Manager : MonoBehaviour {
        public GameObject prefabs;
        public int Count;
        EntityManager entitymanager;
        void Start () {
            entitymanager = World.Active.GetOrCreateManager<EntityManager> ();
            Mathematica (Count);
        }
        void Mathematica (int amount) {
            NativeArray<Entity> entities = new NativeArray<Entity> (amount, Allocator.Temp);
            entitymanager.Instantiate (prefabs, entities);
        }
    }
}