using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace MLplanets {
    public class MLmoveSystem : JobComponentSystem {
        private List<MLspawns> m_MLspawns = new List<MLspawns> ();

        [BurstCompile]
        struct MLmove : IJobProcessComponentData<Position, MLmoveSpeed> {
            public float time;

            public void Execute (ref Position position, [ReadOnly] ref MLmoveSpeed speed) {

            }
        }
        protected override JobHandle OnUpdate (JobHandle inputDeps) {

            var job = new MLmove () { time = Time.time };
            return job.Schedule (this, inputDeps);
        }
    }
}

/* 
namespace MLplanets {
    public class MLmoveSystem : JobComponentSystem {
#pragma warning disable 649
        public struct MLmove {
            [ReadOnly] public ComponentDataArray<MLmoveSpeed> moveSpeed;
            public ComponentDataArray<Position> position;
            public readonly int Lenght;
        }

        [Inject] MLmove m_MLmove;
#pragma warning disable 649
        [BurstCompile]
        private struct MLmoveposition : IJobParallelFor {
            [ReadOnly] public ComponentDataArray<MLmoveSpeed> moveSpeed;
            public ComponentDataArray<Position> position;

            public void Execute (int i) {
                float time = Time.time;
                float angle = math.sin (Mathf.PI * time);
                float x = math.cos (angle);
                float y = x;
                float z = x;

                moveSpeed[i] = new MLmoveSpeed {
                    MoveSpeed = moveSpeed[i].MoveSpeed
                };

                position[i] = new Position {
                    Value = new float3 (x, y, z)
                };
            }
        }
        protected override JobHandle OnUpdate (JobHandle inputDeps) {
            var MLmovepositionJob = new MLmoveposition ();
            MLmovepositionJob.position = m_MLmove.position;
            MLmovepositionJob.moveSpeed = m_MLmove.moveSpeed;
            return MLmovepositionJob.Schedule (m_MLmove.Lenght, 64, inputDeps);
        }
    }
}
*/