using Unity.Entities;
using UnityEngine;

public class MovementAuthoring : MonoBehaviour
{

}

public class MovementBaker : Baker<MovementAuthoring>
{
    public override void Bake(MovementAuthoring authoring)
    {
        Movement movement = new();
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);

        AddComponent(entity, movement);
    }
}
