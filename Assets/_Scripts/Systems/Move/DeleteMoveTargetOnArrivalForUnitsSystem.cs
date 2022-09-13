using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class DeleteMoveTargetOnArrivalForUnitsSystem : IEcsRunSystem
    {
        private EcsFilter<MoveTarget, Position> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                var position = _filter.Get1(index);
                var moveTarget = _filter.Get2(index);

                var distance = Vector2.Distance(position.Value, moveTarget.Value);
                if (distance > 0.05f) continue;
                if (entity.Has<FollowingCursorFlag>())
                {
                    entity.Del<FollowingCursorFlag>();
                }

                if (entity.Has<ControlledByPlayerFlag>())
                {
                    entity.Del<ControlledByPlayerFlag>();
                }
                entity.Del<MoveTarget>();
                entity.Get<Velocity>() = new Velocity()
                {
                    Value = Vector2.zero
                };
            }
        }
    }
}