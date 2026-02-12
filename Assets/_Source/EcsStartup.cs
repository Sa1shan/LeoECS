using Leopotam.EcsLite;
using UnityEngine;

namespace _Source
{
    public class EcsStartup : MonoBehaviour 
    {
        public CounterProvider CounterProvider; 
        public ZigzagProvider SingleBallProvider;
        public BallSpawner Spawner; 
    
        private EcsWorld _world;
        private IEcsSystems _systems;

        void Start() 
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems
                .Add(new CounterSystem())       
                .Add(new ZigzagMovementSystem()) 
                .Init();
            
            if (CounterProvider != null) 
            {
                CounterProvider.Convert(_world, _world.NewEntity());
            }
            if (SingleBallProvider != null) 
            {
                SingleBallProvider.Convert(_world, _world.NewEntity());
            }
            if (Spawner != null) 
            {
                Spawner.SpawnBalls(_world);
            }
        }

        void Update() 
        {
            _systems?.Run();
        }

        void OnDestroy() 
        {
            _systems?.Destroy();
            _systems = null;
            _world?.Destroy();
            _world = null;
        }
    }
}