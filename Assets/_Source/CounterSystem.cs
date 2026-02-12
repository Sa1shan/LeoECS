using Leopotam.EcsLite;

namespace _Source
{
    public class CounterSystem : IEcsRunSystem 
    {
        public void Run(IEcsSystems systems) 
        {
            var world = systems.GetWorld();
            var filter = world.Filter<CounterComponent>().End();
            var pool = world.GetPool<CounterComponent>();

            foreach (var entity in filter) 
            {
                ref var counter = ref pool.Get(entity);
                counter.Value++;
            }
        }
    }
}