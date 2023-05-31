using Unity.Entities;
using Unity.Mathematics;

public struct GlobalRandom : IComponentData
{
    public Random Value;
}
