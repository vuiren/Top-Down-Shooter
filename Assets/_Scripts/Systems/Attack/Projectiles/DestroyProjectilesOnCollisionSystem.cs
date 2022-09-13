using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class DestroyProjectilesOnCollisionSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<ProjectileFlag, OnCollisionEnterEvent> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                entity.Get<DeathFlag>();
            }
        }
    }
}