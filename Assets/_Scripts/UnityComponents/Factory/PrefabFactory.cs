using Client.Components;
using Client.UnityComponents.MonoLinks;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents.Factory
{
    public class PrefabFactory : MonoBehaviour
    {
        private EcsWorld _world;
		
        public void SetWorld(EcsWorld world)
        {
            _world = world;
        }
		
        public void Spawn(SpawnPrefab spawnData)
        {
            var gameObject = Instantiate(spawnData.Prefab, spawnData.Position, spawnData.Rotation, spawnData.Parent);
            var monoEntity = gameObject.GetComponent<MonoEntity>();
            if (monoEntity == null) 
                return;
            var ecsEntity = _world.NewEntity();
            monoEntity.Make(ref ecsEntity);
        }
    }
}