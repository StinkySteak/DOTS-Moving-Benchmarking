using Unity.Entities;
using Unity.Mathematics;

public partial class RandomMovingCharacterSpawnerSystem : SystemBase
{
    protected override void OnUpdate() { }

    protected override void OnStartRunning()
    {
        RandomMovingCharacterSpawningProperty property = SystemAPI.GetSingleton<RandomMovingCharacterSpawningProperty>();
        RefRW<GlobalRandom> random = SystemAPI.GetSingletonRW<GlobalRandom>();

        for (int i = 0; i < property.SpawnAmount; i++)
        {
            Entity entity = EntityManager.Instantiate(property.MovingCharacterPrefab);

            RandomPathfindingTransform aspect = EntityManager.GetAspect<RandomPathfindingTransform>(entity);

            float3 newDestination = GetRandomPosition(random, property);

            aspect.SetNewDestination(newDestination);
        }
    }

    private float3 GetRandomPosition(RefRW<GlobalRandom> random, RandomMovingCharacterSpawningProperty spawningProperty)
    {
        float x = GetSpawnPositionAxis(random, spawningProperty.SpawnRadius) + spawningProperty.SpawnPosition.x;
        float z = GetSpawnPositionAxis(random, spawningProperty.SpawnRadius) + spawningProperty.SpawnPosition.z;

        return new float3()
        {
            x = x,
            y = 0,
            z = z,
        };
    }

    private float GetSpawnPositionAxis(RefRW<GlobalRandom> random, float spawnRadius)
        => random.ValueRW.Value.NextFloat(-1f, 1f) * spawnRadius;
}
