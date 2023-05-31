using Unity.Entities;

public partial class CharacterMovementSystem : SystemBase
{
    protected override void OnUpdate()
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
