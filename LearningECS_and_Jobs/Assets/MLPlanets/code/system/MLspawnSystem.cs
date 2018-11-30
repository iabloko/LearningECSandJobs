using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace MLplanets {
    public class MLspawnSystem : ComponentSystem {
#pragma warning disable 649
        struct MLspawn {
            [ReadOnly] public SharedComponentDataArray<MLspawns> mlSpawn;
            public ComponentDataArray<Position> position;
            public EntityArray entity;
            public readonly int Length;
        }

        [Inject] MLspawn m_MLspawn;
#pragma warning restore 649

        protected override void OnUpdate () {
            while (m_MLspawn.Length != 0) {
                var spawner = m_MLspawn.mlSpawn[0];
                var sourseEntity = m_MLspawn.entity[0];
                var center = m_MLspawn.position[0].Value;

                var entities = new NativeArray<Entity> (spawner.count, Allocator.Temp);
                EntityManager.Instantiate (spawner.MLspawnGameObject, entities);

                var positions = new NativeArray<float3> (spawner.count, Allocator.Temp);

                //MLgeneratePoints.MLrandomGenerate (new float3 (), ref positions);

                MLgeneratePoints.MLTryToSin (new float3 (), ref positions);

                for (int i = 0; i < spawner.count; i++) {
                    var position = new Position {
                        Value = positions[i]
                    };

                    EntityManager.SetComponentData (entities[i], position);

                    var attach = EntityManager.CreateEntity ();
                    EntityManager.AddComponentData (attach, new Attach {
                        Parent = sourseEntity,
                            Child = entities[i]
                    });
                }
                entities.Dispose ();
                positions.Dispose ();
                EntityManager.RemoveComponent<MLspawns> (sourseEntity);
                UpdateInjectedComponentGroups ();
            }
        }
    }
}