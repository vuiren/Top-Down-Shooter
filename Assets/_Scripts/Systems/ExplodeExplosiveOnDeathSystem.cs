using Client.Components;
using Client.UnityComponents;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class ExplodeExplosiveOnDeathSystem: IEcsRunSystem
    {
        private EcsWorld _world;
        private Configuration _configuration;
        private EcsFilter<DeathFlag, ExplosiveFlag, Position> _filter;
        public void Run()
        {
            foreach (var index in _filter)
            {
                _world.NewEntity().Get<SpawnPrefab>() = new SpawnPrefab()
                {
                    Prefab = _configuration.explosionPrefab,
                    Parent = null,
                    Position = _filter.Get3(index).Value
                };
            }
            
        }
    }
}