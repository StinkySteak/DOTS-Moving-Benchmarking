using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

[BurstCompile]
public partial struct CharacterPathfindingMovement : ISystem
{
    [BurstCompile]
    public  void OnUpdate(ref SystemState state)
    {
        GlobalCharacterMovementSpeed movementSpeed = SystemAPI.GetSingleton<GlobalCharacterMovementSpeed>();

        foreach (PathfindingMovementAspect aspect in SystemAPI.Query<PathfindingMovementAspect>())
        {
            float3 moveDirection = aspect.PathfindingDestination.ValueRO.Position - aspect.Transform.ValueRO.Position;

            moveDirection = math.normalize(moveDirection);
            float3 velocity = movementSpeed.Speed * moveDirection;

            aspect.Movement.ValueRW.Velocity = velocity;
        }
    }

    [BurstCompile]
    public void OnCreate(ref SystemState state) { }

    [BurstCompile]
    public void OnDestroy(ref SystemState state) { }
}
