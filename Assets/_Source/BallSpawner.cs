using Leopotam.EcsLite;
using UnityEngine;

namespace _Source
{
    public class BallSpawner : MonoBehaviour 
    {
        public GameObject BallPrefab;
        public int Count = 1000;
        public EcsStartup StartupScript; 
        
        public void SpawnBalls(EcsWorld world) {
            for (int i = 0; i < Count; i++) {
                Vector3 pos = new Vector3(Random.Range(-50f, 50f), 0, 0); 
                var go = Instantiate(BallPrefab, pos, Quaternion.identity);
                var provider = go.GetComponent<ZigzagProvider>();
                var entity = world.NewEntity();
                provider.Convert(world, entity);
                var pool = world.GetPool<ZigzagMoveComponent>();
                ref var comp = ref pool.Get(entity);
                comp.StartPosition = pos;
                comp.TimeOffset = Random.Range(0f, 10f); 
            }
        }
    }
}