using Unity.Entities;
using Unity.Mathematics;

public partial struct RandomPathfindingSystem : ISystem
{
    public void OnCreate(ref SystemState state) { }
    public void OnDestroy(ref SystemState state) { }
    public void OnUpdate(ref SystemState state)
    {
        RefRW<GlobalRandom> random = SystemAPI.GetSingletonRW<GlobalRandom>();
        RandomPathfindingProperty property = SystemAPI.GetSingleton<RandomPathfindingProperty>();

        foreach (RandomPathfindingTransform aspect in SystemAPI.Query<RandomPathfindingTransform>())
        {
            float distance = math.distance(aspect.EntityPosition, aspect.EntityDestination);

            bool isDistanceReached = distance <= property.MinReachDistance;

            if (isDistanceReached)
            {
                float3 newDestination = GetRandomPosition(random, property);

                aspect.SetNewDestination(newDestination);
            }
        }
    }

    private float3 GetRandomPosition(RefRW<GlobalRandom> random, RandomPathfindingProperty property)
    {
        float x = random.ValueRW.Value.NextFloat(-1f, 1f) * property.MaxRadius;
        float z = random.ValueRW.Value.NextFloat(-1f, 1f) * property.MaxRadius;

        return new float3()
        {
            x = x,
            y = 0,
            z = z,
        };
    }
}
