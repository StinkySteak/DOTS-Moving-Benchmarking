using Unity.Entities;
using Unity.Transforms;

public readonly partial struct PathfindingMovementAspect : IAspect
{
    private readonly Entity entity;

    public readonly RefRW<Movement> Movement;
    public readonly RefRO<PathfindingDestination> PathfindingDestination;
    public readonly RefRO<LocalTransform> Transform;
}
