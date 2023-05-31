using Unity.Entities;
using Unity.Transforms;

public readonly partial struct MovingTransformAspect : IAspect
{
    private readonly Entity _entity;
    public readonly RefRW<Movement> Movement;
    public readonly RefRW<LocalTransform> Transform;
}
