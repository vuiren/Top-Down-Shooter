using Client.Components;
using Client.Extensions;
using Client.UnityComponents.Util;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class SlideOnColliders : IEcsRunSystem
    {
        private EcsFilter<Position, Velocity, CollisionData> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                var pos = entity.Get<Position>();
                var velocity = entity.Get<Velocity>();
                var mask = _filter.Get3(index);
                var col = Physics2D.OverlapCircle(pos.Value + velocity.Value * Time.deltaTime, mask.CollisionRadius,
                    mask.CollisionMask);
                if (col)
                {
                    var point = col.ClosestPoint(pos.Value);
                    var normal = pos.Value - point;

                    var newVector = velocity.Value.x > 0
                        ? normal.Rotate90Clockwise()
                        : normal.Rotate90AntiClockwise();

                    if (velocity.Value.x > 0 && velocity.Value.y > 0)
                    {
                        newVector = normal.Rotate90AntiClockwise();
                    }

                    if (velocity.Value.x < 0 && velocity.Value.y > 0)
                    {
                        newVector = normal.Rotate90Clockwise();
                    }

                    if (velocity.Value.x > 0 && velocity.Value.y < 0)
                    {               
                        newVector = normal.Rotate90Clockwise();
                    }
                    
                    if (velocity.Value.x < 0 && velocity.Value.y < 0)
                    {               
                        newVector = normal.Rotate90AntiClockwise();
                    }

                    Debug.Log("Gotcha " + col.gameObject.name);
                    entity.Get<Velocity>() = new Velocity()
                    {
                        Value = newVector.normalized * velocity.Value.magnitude
                    };
                }
            }
        }
    }
}