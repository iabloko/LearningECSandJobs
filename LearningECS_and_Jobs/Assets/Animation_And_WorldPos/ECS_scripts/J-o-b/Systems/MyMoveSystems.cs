using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
/*
namespace Math {
    public class MyMoveSystems : JobComponentSystem {
        [ComputeJobOptimization]
        struct MoveJobs : IJobProcessComponentData<Position, Rotation, MoveSpeed> {
            public float deltaTime;
            public int i;

            public void Execute (ref Position position, [ReadOnly] ref Rotation rotation, ref MoveSpeed movespeed) {
                float3 value = position.Value;
                value += deltaTime * movespeed.value * math.forward (rotation.Value);
                position.Value = value;
            }
        }
        protected override JobHandle OnUpdate (JobHandle inputDeps) {
            MyMoveSystems moveJob = new MyMoveSystems {
                deltaTime = Time.deltaTime
            };
            JobHandle moveHandle = moveJob.Schedule (this, 64, inputDeps);
            return moveHandle;
        }
    }
}
 */