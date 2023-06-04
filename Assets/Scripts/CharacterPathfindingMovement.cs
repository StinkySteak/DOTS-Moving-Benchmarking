using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public partial class CharacterPathfindingMovement : SystemBase
{
    protected override void OnUpdate()
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
}
