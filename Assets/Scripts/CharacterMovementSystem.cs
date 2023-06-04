using Unity.Entities;

public partial struct CharacterMovementSystem : ISystem
{
    public void OnCreate(ref SystemState state) { }
    public void OnDestroy(ref SystemState state) { }
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = state.World.Time.DeltaTime;

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
