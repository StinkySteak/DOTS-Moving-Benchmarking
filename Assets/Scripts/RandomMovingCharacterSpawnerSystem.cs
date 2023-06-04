using Unity.Entities;
using Unity.Mathematics;

public partial class RandomMovingCharacterSpawnerSystem : SystemBase
{
    protected override void OnUpdate() { }

    protected override void OnStartRunning()
    {
        SpawnCharacters();
    }

    private void SpawnCharacters()
    {
        RandomMovingCharacterSpawningProperty property = SystemAPI.GetSingleton<RandomMovingCharacterSpawningProperty>();

        for (int i = 0; i < property.SpawnAmount; i++)
        {
            Entity entity = EntityManager.Instantiate(property.MovingCharacterPrefab);

            EntityManager.AddComponent<PathfindingDestination>(entity);

            RandomPathfindingTransform aspect = EntityManager.GetAspect<RandomPathfindingTransform>(entity);

            float3 newDestination = GetRandomPosition(property);

            aspect.SetNewDestination(newDestination);
        }
    }

    private float3 GetRandomPosition(RandomMovingCharacterSpawningProperty spawningProperty)
    {
        RefRW<GlobalRandom> random = SystemAPI.GetSingletonRW<GlobalRandom>();

        float x = random.ValueRW.Value.NextFloat(-1f, 1f) * spawningProperty.SpawnRadius;
        float z = random.ValueRW.Value.NextFloat(-1f, 1f) * spawningProperty.SpawnRadius;

        return new float3()
        {
            x = x,
            y = 0,
            z = z,
        };
    }
}
