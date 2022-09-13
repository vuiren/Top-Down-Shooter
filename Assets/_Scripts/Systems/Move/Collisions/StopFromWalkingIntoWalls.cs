using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems.Collisions
{
    public class StopFromWalkingIntoWalls: IEcsRunSystem
    {
        private EcsFilter<Position, Velocity, CollisionData> _filter;
        public void Run()
        {
            foreach (var index in _filter)
            {
                var position = _filter.Get1(index);
                ref var velocity = ref _filter.Get2(index);
                var data = _filter.Get3(index);
                var hit = Physics2D.OverlapCircle(position.Value + velocity.Value, data.CollisionRadius,
                    data.CollisionMask);

                if (hit)
                {
                    velocity = new Velocity()
                    {
                        Value = Vector2.zero
                    };
                }
            }
        }
    }
}