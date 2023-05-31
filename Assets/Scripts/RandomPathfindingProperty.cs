using Unity.Entities;
using Unity.Mathematics;

public struct RandomPathfindingProperty : IComponentData
{
    public float MinReachDistance;
    public float MaxRadius;
    public float3 CenterPosition;

    public int EntitiesSpawnAmount;
}
