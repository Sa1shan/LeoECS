using Leopotam.EcsLite;
using UnityEngine;

namespace _Source
{
    public class ZigzagMovementSystem : IEcsRunSystem 
    {
        public void Run(IEcsSystems systems) 
        {
            var world = systems.GetWorld();
            var filter = world.Filter<ZigzagMoveComponent>().End();
            var pool = world.GetPool<ZigzagMoveComponent>();

            foreach (var entity in filter) 
            {
                ref var moveData = ref pool.Get(entity);
                moveData.TimeOffset += Time.deltaTime;
                Vector3 currentPos = moveData.Transform.position;
                float zOffset = moveData.ForwardSpeed * Time.deltaTime;
                float xOffset = Mathf.Sin(moveData.TimeOffset * moveData.Frequency) * moveData.SideAmplitude;
                Vector3 newPos = currentPos;
                newPos.z += zOffset;
                newPos.x = moveData.StartPosition.x + xOffset;
                moveData.Transform.position = newPos;
            }
        }
    }
}