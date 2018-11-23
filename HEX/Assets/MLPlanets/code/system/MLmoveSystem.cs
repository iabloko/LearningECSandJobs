using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace MLplanets {
    public class MLmoveSystem : JobComponentSystem {
#pragma warning disable 649
        struct MLmoveGroup {
            public ComponentDataArray<Position> positions;
            public ComponentDataArray<MLmove> MLmove;
            public readonly int Length;
        }

        [Inject] private MLmoveGroup m_MLmoveGroup;
#pragma warning restore 649    

        [BurstCompile]
        struct MLmovePosition : IJobParallelFor {
            public ComponentDataArray<Position> positions;
            public ComponentDataArray<MLmove> MLmove;
            public float deltaTime;
            private float dt;

            public void Execute (int i) {
                float3 prevPosition = positions[i].Value;
                MLmove prevMLmove = MLmove[i];

                float time = MLmove[i].t;
                float sin = math.sin (time + i);

                positions[i] = new Position {
                    Value = prevPosition + new float3 (sin * prevMLmove.height.x, sin * prevMLmove.height.y, sin * prevMLmove.height.z)
                };

                MLmove[i] = new MLmove {
                    t = prevMLmove.t + (deltaTime * prevMLmove.speed),
                    height = prevMLmove.height,
                    speed = prevMLmove.speed
                };
            }
        }

        protected override JobHandle OnUpdate (JobHandle inputDeps) {
            var bouncePositionJob = new MLmovePosition ();
            bouncePositionJob.positions = m_MLmoveGroup.positions;
            bouncePositionJob.MLmove = m_MLmoveGroup.MLmove;
            bouncePositionJob.deltaTime = Time.deltaTime;
            return bouncePositionJob.Schedule (m_MLmoveGroup.Length, 64, inputDeps);
        }
    }
}