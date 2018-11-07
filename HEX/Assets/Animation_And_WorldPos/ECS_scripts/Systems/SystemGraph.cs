using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Math {
    public class SystemGraph : JobComponentSystem {

        [ComputeJobOptimization]
        struct GraphJob : IJobProcessComponentData<Position, Rotation, Count> {

            public int variable_top;
            public int variable_bot;
            public float deltaTime;

            public void Execute (ref Position position, [ReadOnly] ref Rotation rotation, [ReadOnly] ref Count count) {
                float3 value = position.Value;
                value += Time.deltaTime * count.value * math.forward (rotation.Value);
                if (value.z < variable_bot)
                    value.z = variable_top;

                position.Value = value;
            }
        }
        protected override JobHandle OnUpdate (JobHandle inputDeps) {
            GraphJob graphJob = new GraphJob {
                variable_top = ManagerGame.MG.top,
                variable_bot = ManagerGame.MG.bot,
                deltaTime = Time.deltaTime
            };

            return graphJob.Schedule<GraphJob> (this, inputDeps);
        }
    }
}