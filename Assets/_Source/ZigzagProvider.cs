using Leopotam.EcsLite;
using UnityEngine;

namespace _Source
{
    public class ZigzagProvider : MonoBehaviour 
    {
        public float ForwardSpeed = 5f;
        public float SideAmplitude = 2f;
        public float Frequency = 2f;
        public void Convert(EcsWorld world, int entity) 
        {
            var pool = world.GetPool<ZigzagMoveComponent>();
            ref var component = ref pool.Add(entity);
        
            component.Transform = transform;
            component.ForwardSpeed = ForwardSpeed;
            component.SideAmplitude = SideAmplitude;
            component.Frequency = Frequency;
            component.StartPosition = transform.position;
            component.TimeOffset = 0;
        }
    }
}