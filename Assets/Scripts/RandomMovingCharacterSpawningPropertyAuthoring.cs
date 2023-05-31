using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class RandomMovingCharacterSpawningPropertyAuthoring : MonoBehaviour
{
    public GameObject MovingCharacterPrefab;
    public int SpawnAmount;

    public float3 SpawnPosition;
    public float SpawnRadius;
}

public class RandomMovingCharacterSpawningPropertyBaker : Baker<RandomMovingCharacterSpawningPropertyAuthoring>
{

    public override void Bake(RandomMovingCharacterSpawningPropertyAuthoring authoring)
    {
        RandomMovingCharacterSpawningProperty property = new()
        {
            SpawnAmount = authoring.SpawnAmount,
            MovingCharacterPrefab = GetEntity(authoring.MovingCharacterPrefab, TransformUsageFlags.Dynamic),
            SpawnPosition = authoring.SpawnPosition,
            SpawnRadius = authoring.SpawnRadius,
        };


        Entity entity = GetEntity(TransformUsageFlags.None);
        AddComponent(entity, property);
    }
}