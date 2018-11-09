using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Samples.Common {
    /* 
    public class MySpawnSystems : ComponentSystem {
#pragma warning disable 649
        struct Data {
            [ReadOnly] public SharedComponentDataArray<SpawnSpheres> spawnSpheres;
            public ComponentDataArray<Position> position;
            public EntityArray entity;
            public readonly int Length;
        }

        [Inject] Data m_data;
#pragma warning restore 649

        protected override void OnUpdate () {
            while (m_data.Length != 0) {
                var _spawnSpeheres = m_data.spawnSpheres[0];
                var _entity = m_data.entity[0];

                var entities = new NativeArray<Entity> (_spawnSpeheres.count, Allocator.Temp);
                EntityManager.Instantiate (_spawnSpeheres.prefab, entities);
                var positions = new NativeArray<float3> (_spawnSpeheres.count, Allocator.Temp);

                GeneratePoints.RandomPointsOnCircle (new float3 (), 5, ref positions);
                for (int i = 0; i < _spawnSpeheres.count; i++) {
                    var position = new Position {
                        Value = positions[i]
                    };
                    EntityManager.SetComponentData (entities[i], position);
                    //------------------------------------------------------
                    var attach = EntityManager.CreateEntity ();
                    EntityManager.AddComponentData (attach, new Attach {
                        Parent = _entity,
                            Child = entities[i]
                    });
                    entities.Dispose ();
                    positions.Dispose ();

                    EntityManager.RemoveComponent<SpawnSpheres> (_entity);
                    UpdateInjectedComponentGroups ();

                }
            }
        }
    }
*/
    public class MySpawnSystems : JobComponentSystem {
        [ComputeJobOptimization]
        struct Data : IJobProcessComponentData<Position, Rotation> {
            [ReadOnly] public SharedComponentDataArray<SpawnSpheres> spawnSpheres;
            public ComponentDataArray<Position> position;
            public EntityArray entity;
            public readonly int Length;

            public void Execute (ref Position position, [ReadOnly] ref Rotation rotation) {

            }
        }
    }
}