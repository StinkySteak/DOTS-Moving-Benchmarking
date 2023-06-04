using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

[BurstCompile]
public partial struct CharacterPathfindingMovement : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        GlobalCharacterMovementSpeed movementSpeed = SystemAPI.GetSingleton<GlobalCharacterMovementSpeed>();

        SetVelocityJob job = new()
        {
            globalMovementSpeed = movementSpeed,
        };

        job.ScheduleParallel();
    }

    [BurstCompile]
    public void OnCreate(ref SystemState state) { }

    [BurstCompile]
    public void OnDestroy(ref SystemState state) { }
}

[BurstCompile]
public partial struct SetVelocityJob : IJobEntity
{
    public GlobalCharacterMovementSpeed globalMovementSpeed;

    [BurstCompile]
    public void Execute(PathfindingMovementAspect aspect)
    {
        float3 moveDirection = aspect.PathfindingDestination.ValueRO.Position - aspect.Transform.ValueRO.Position;

        moveDirection = math.normalize(moveDirection);
        float3 velocity = globalMovementSpeed.Speed * moveDirection;

        aspect.Movement.ValueRW.Velocity = velocity;
    }
}
