using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Math {
    public class ManagerGame : MonoBehaviour {
        EntityManager entityManager;
        public GameObject _prefab;

        private Transform[] points;
        const float _PI = Mathf.PI;

        public int top = 16;
        public int bot = 5;

        public static ManagerGame MG;

        private void Update () {
            if (Input.GetKeyUp (KeyCode.Space)) {
                TestMethod (10);
            }
        }

        void Start () {
            entityManager = World.Active.GetOrCreateManager<EntityManager> ();
        }

        void TestMethod (int amount) {
            NativeArray<Entity> entities = new NativeArray<Entity> (amount, Allocator.Temp);
            entityManager.Instantiate (_prefab, entities);

            for (int i = 0; i < amount; i++) {
                Debug.Log ("Test");
                float xVal = UnityEngine.Random.Range (0f, 10f);
                float zVal = UnityEngine.Random.Range (10f, 20f);
                entityManager.SetComponentData (entities[i], new Position { Value = new float3 (xVal, 0f, zVal) });
                entityManager.SetComponentData (entities[i], new Rotation { Value = new quaternion (0, 0, 1, 0) });
            }
            entities.Dispose ();
        }
    }

}