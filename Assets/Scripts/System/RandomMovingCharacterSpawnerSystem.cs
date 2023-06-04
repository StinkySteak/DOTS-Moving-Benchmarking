using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

[BurstCompile]
public partial struct RandomMovingCharacterSpawnerSystem : ISystem, ISystemStartStop
{
    [BurstCompile]
    public void OnCreate(ref SystemState state) { }
    [BurstCompile]
    public void OnUpdate(ref SystemState state) { }
    [BurstCompile]
    public void OnDestroy(ref SystemState state) { }
    public void OnStartRunning(ref SystemState state)
    {
        SpawnCharacters(state.EntityManager);
    }

    private void SpawnCharacters(EntityManager em)
    {
        RandomMovingCharacterSpawningProperty property = SystemAPI.GetSingleton<RandomMovingCharacterSpawningProperty>();

        for (int i = 0; i < property.SpawnAmount; i++)
        {
            Entity entity = em.Instantiate(property.MovingCharacterPrefab);

            em.AddComponent<PathfindingDestination>(entity);

            RandomPathfindingTransform aspect = em.GetAspect<RandomPathfindingTransform>(entity);

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

    public void OnStopRunning(ref SystemState state)
    {
    }
}
