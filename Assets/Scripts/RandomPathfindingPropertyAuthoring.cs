using Unity.Entities;
using UnityEngine;

public class RandomPathfindingPropertyAuthoring : MonoBehaviour
{
    public float MinReachDistance;
    public Vector3 CenterPosition;
    public float MaxRadius;
}

public class RandomPathfindingPropertyBaker : Baker<RandomPathfindingPropertyAuthoring>
{
    public override void Bake(RandomPathfindingPropertyAuthoring authoring)
    {
        RandomPathfindingProperty property = new()
        {
            MaxRadius = authoring.MaxRadius,
            MinReachDistance = authoring.MinReachDistance,
            CenterPosition = authoring.CenterPosition,
        };

        Entity entity = GetEntity(TransformUsageFlags.None);
        AddComponent(entity, property);
    }
}