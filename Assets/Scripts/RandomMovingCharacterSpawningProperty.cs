using Unity.Entities;
using Unity.Mathematics;

public struct RandomMovingCharacterSpawningProperty : IComponentData
{
    public Entity MovingCharacterPrefab;
    public int SpawnAmount;

    public float3 SpawnPosition;
    public float SpawnRadius;
}
