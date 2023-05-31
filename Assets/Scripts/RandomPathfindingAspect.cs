using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public readonly partial struct RandomPathfindingTransform : IAspect
{
    private readonly Entity _entity;
    private readonly RefRO<LocalTransform> Transform;
    public readonly RefRW<PathfindingDestination> PathfindingDestination;

    public float3 EntityPosition => Transform.ValueRO.Position;
    public float3 EntityDestination => PathfindingDestination.ValueRO.Position;

    public void SetNewDestination(float3 destination)
    {
        PathfindingDestination.ValueRW.Position = destination;
    }
}
