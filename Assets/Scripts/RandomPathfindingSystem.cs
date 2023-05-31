using Unity.Entities;
using Unity.Mathematics;

public partial class RandomPathfindingSystem : SystemBase
{

    protected override void OnUpdate()
    {
        RefRW<GlobalRandom> random = SystemAPI.GetSingletonRW<GlobalRandom>();
        RandomPathfindingProperty property = SystemAPI.GetSingleton<RandomPathfindingProperty>();

        foreach (RandomPathfindingTransform aspect in SystemAPI.Query<RandomPathfindingTransform>())
        {
            float distance = math.distance(aspect.EntityPosition, aspect.EntityDestination);

            bool isDistanceReached = distance <= property.MinReachDistance;

            if (isDistanceReached)
            {
                float3 newDestination = GetRandomPosition(random);

                aspect.SetNewDestination(newDestination);
            }
        }
    }

    private float3 GetRandomPosition(RefRW<GlobalRandom> random)
    {
        return new float3()
        {
            x = random.ValueRW.Value.NextFloat(),
            y = 0,
            z = random.ValueRW.Value.NextFloat(),
        };
    }
}
