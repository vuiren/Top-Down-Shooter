using Client.Components;
using Client.Components.Animation;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems.Animation
{
    public class UpdateUnitStateSystem : IEcsRunSystem
    {
        private EcsFilter<UnitFlag> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);

                if (entity.Has<FollowingAttackTargetFlag>())
                {
                    entity.Get<UnitState>() = new UnitState()
                    {
                        Value = UnitStateEnum.Walk
                    };
                    return;
                }

                if (entity.Has<AttackTarget>())
                {
                    entity.Get<UnitState>().Value = UnitStateEnum.Shoot;
                    return;
                }

                if (entity.Has<Velocity>())
                {
                    var velocity = entity.Get<Velocity>();

                    if (!Mathf.Approximately(velocity.Value.x, 0f))
                    {
                        entity.Get<UnitState>().Value = UnitStateEnum.Walk;
                        return;
                    }
                }

                entity.Get<UnitState>().Value = UnitStateEnum.Idle;
            }
        }
    }
}