using Unity.Entities;

public partial class SystemSingletonComponentInitializer : SystemBase
{
    protected override void OnStartRunning()
    {
        //RefRW<GlobalRandom> random = SystemAPI.GetSingletonRW<GlobalRandom>();

        //random.ValueRW.Value.InitState();
    }
    protected override void OnUpdate() { }
}