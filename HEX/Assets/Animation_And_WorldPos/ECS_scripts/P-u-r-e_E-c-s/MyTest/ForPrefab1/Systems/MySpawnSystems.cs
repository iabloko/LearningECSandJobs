using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Samples.Common {
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

                if (_spawnSpeheres.spawnLocal) {
                    MyGenerateforPoints.SineFunction (1, 1, 1);
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
                    }
                }

                entities.Dispose ();
                positions.Dispose ();

                EntityManager.RemoveComponent<SpawnSpheres> (_entity);
                UpdateInjectedComponentGroups ();
            }
        }
    }
}