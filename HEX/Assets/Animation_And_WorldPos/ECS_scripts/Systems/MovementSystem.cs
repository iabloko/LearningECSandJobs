using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace TestECS {
    public class MovementSystem : JobComponentSystem {
        [ComputeJobOptimization]
        struct MovementJob : IJobProcessComponentData<Position, Rotation> {
            public float Top;
            public float Bott;
            public float deltatime;
            public void Execute (ref Position position, [ReadOnly] ref Rotation rotation) {
                float3 value = position.Value;
                value += deltatime * math.forward (rotation.Value);
                position.Value = value;
            }
        }
        protected override JobHandle OnUpdate (JobHandle inputs) {
            MovementJob movetJob = new MovementJob {
                Top = 1,
                Bott = 2,
                deltatime = Time.deltaTime
            };
            JobHandle moveHandle = movetJob.Schedule (this, 64, inputs);
            return moveHandle;
        }
    }
}