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
        struct BouncePosition : IJobParallelFor {
            public ComponentDataArray<Position> positions;
            public ComponentDataArray<MLmove> MLmove;
            public float dt;

            public void Execute (int i) {
                float t = MLmove[i].t + i;
                float st = math.sin (t);
                float3 prevPosition = positions[i].Value;
                MLmove prevMLmove = MLmove[i];

                positions[i] = new Position {
                    Value = prevPosition + new float3 (st * prevMLmove.height.x, st * prevMLmove.height.y, st * prevMLmove.height.z)
                };

                MLmove[i] = new MLmove {
                    t = prevMLmove.t + (dt * prevMLmove.speed),
                    height = prevMLmove.height,
                    speed = prevMLmove.speed
                };
            }
        }

        protected override JobHandle OnUpdate (JobHandle inputDeps) {
            var bouncePositionJob = new BouncePosition ();
            bouncePositionJob.positions = m_MLmoveGroup.positions;
            bouncePositionJob.MLmove = m_MLmoveGroup.MLmove;
            bouncePositionJob.dt = Time.deltaTime;
            return bouncePositionJob.Schedule (m_MLmoveGroup.Length, 64, inputDeps);
        }
    }
}