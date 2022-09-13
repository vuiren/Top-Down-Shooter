using Client.Components;
using Client.UnityComponents.Factory;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class SpawnSystem : IEcsPreInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<SpawnPrefab> _filter;
        private PrefabFactory prefabFactory;

        public void PreInit()
        {
            prefabFactory.SetWorld(_world);
        }

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                
                prefabFactory.Spawn(entity.Get<SpawnPrefab>());
                entity.Del<SpawnPrefab>();
            }
        }
    }
}