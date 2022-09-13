using Client.Components;
using Client.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems.Ground
{
    public class FindGroundPointSystem : IEcsRunSystem
    {
        private EcsFilter<GroundPoint> _filter;
        private Configuration configuration;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                var pos = entity.Get<Position>();
                var a = Physics2D.Raycast(pos.Value + Vector2.up, Vector2.down, 10, configuration.GroundLayers);
                if (a)
                {
                    entity.Get<GroundPoint>() = new GroundPoint()
                    {
                        Value = a,
                        point = a.point
                    };
                }
            }
        }
    }
}