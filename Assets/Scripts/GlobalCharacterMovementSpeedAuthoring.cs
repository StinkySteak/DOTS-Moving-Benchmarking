using Unity.Entities;
using UnityEngine;

public class GlobalCharacterMovementSpeedAuthoring : MonoBehaviour
{
    public float Speed;
}

public class GlobalCharacterMovementBaker : Baker<GlobalCharacterMovementSpeedAuthoring>
{
    public override void Bake(GlobalCharacterMovementSpeedAuthoring authoring)
    {
        GlobalCharacterMovementSpeed speed = new() { Speed = authoring.Speed };
        Entity entity = GetEntity(TransformUsageFlags.None);
        AddComponent(entity, speed);
    }
}
