using Unity.Entities;
using UnityEngine;

public class GlobalRandomAuthoring : MonoBehaviour
{
    public uint Seed;
}

public class GlobalRandomBaker : Baker<GlobalRandomAuthoring>
{
    public override void Bake(GlobalRandomAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.None);
        GlobalRandom random = new()
        {
            Value = new Unity.Mathematics.Random(authoring.Seed)
        };
        AddComponent(entity, random);
    }
}