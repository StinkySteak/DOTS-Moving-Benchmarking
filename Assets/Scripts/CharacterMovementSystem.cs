using Unity.Burst;
using Unity.Entities;

[BurstCompile]
public partial struct CharacterMovementSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state) { }
    [BurstCompile]
    public void OnDestroy(ref SystemState state) { }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;

        MoveJob job = new()
        {
            DeltaTime = deltaTime,
        };

        job.ScheduleParallel();
    }
}

[BurstCompile]
public partial struct MoveJob : IJobEntity
{
    public float DeltaTime;

    [BurstCompile]
    public void Execute(MovingTransformAspect aspect)
    {
        aspect.Transform.ValueRW.Position += aspect.Movement.ValueRO.Velocity * DeltaTime;
    }
}
