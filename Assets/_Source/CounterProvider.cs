using Leopotam.EcsLite;
using UnityEngine;

namespace _Source
{
    public class CounterProvider : MonoBehaviour 
    {
        public int InitialValue = 0;
        public void Convert(EcsWorld world, int entity) {
            var pool = world.GetPool<CounterComponent>();
            ref var component = ref pool.Add(entity);
            component.Value = InitialValue;
        }
    }
}