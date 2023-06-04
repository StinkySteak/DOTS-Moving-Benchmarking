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

        foreach (MovingTransformAspect aspect in SystemAPI.Query<MovingTransformAspect>())
        {
            Move(aspect, deltaTime);
        }
    }

    private void Move(MovingTransformAspect aspect, float deltaTime)
    {
        aspect.Transform.ValueRW.Position += aspect.Movement.ValueRO.Velocity * deltaTime;
    }
}
