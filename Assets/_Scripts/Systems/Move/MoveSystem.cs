using Client.Components;
using Client.Extensions;
using Client.UnityComponents.MonoLinks;
using Client.UnityComponents.Util;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class MoveSystem : IEcsRunSystem
    {
        private EcsWorld _ecsWorld;
        private EcsFilter<GameObjectLink, Velocity> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var a = ref _filter.GetEntity(index);

                ref var position = ref a.Get<Position>();
                var velocity = a.Get<Velocity>();

                position.Value += velocity.Value * Time.deltaTime;
            }
        }
    }
}