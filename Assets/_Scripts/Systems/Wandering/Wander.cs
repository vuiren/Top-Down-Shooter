using Client.Components;
using Client.Components.Wandering;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems.Wandering
{
    public class Wander : IEcsRunSystem
    {
        private EcsFilter<WandererFlag> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                if (entity.Has<MoveTarget>()) continue;

                var dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                entity.Get<MoveTarget>() = new MoveTarget()
                {
                    Value = dir
                };
            }
        }
    }
}