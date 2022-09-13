using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems.Ground
{
    public class StickEntityToTheGroundSystem : IEcsRunSystem
    {
        private EcsFilter<GroundPoint> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                var groundPoint = _filter.Get1(index);
                var normal = groundPoint.Value.normal;

                var velocity = entity.Get<Velocity>();
                if (Mathf.Approximately(velocity.Value.magnitude, 0)) continue;


                var newDirection = new Vector2(normal.y, -normal.x);
                entity.Get<Velocity>() = new Velocity()
                {
                    Value = velocity.Value.x > 0 ? newDirection : newDirection * -1
                };
            }
        }
    }
}