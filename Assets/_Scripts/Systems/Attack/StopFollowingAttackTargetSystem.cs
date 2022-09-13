using Client.Components;
using Client.Components.Navigation;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class StopFollowingAttackTargetSystem: IEcsRunSystem
    {
        private EcsFilter<AttackTarget, AttackStartDistance, FollowingAttackTargetFlag> _filter;
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);

                var attackTarget = _filter.Get1(index);
                if (!attackTarget.Value.IsAlive()) return;

                var entityPosition = entity.Get<Position>();
                var attackTargetPosition = attackTarget.Value.Get<Position>();

                var distance = Vector2.Distance(entityPosition.Value, attackTargetPosition.Value);
                var attackStartDistance = _filter.Get2(index);

                if (distance < attackStartDistance.Value)
                {
                    entity.Del<FollowingAttackTargetFlag>();
                    entity.Del<Path>();
                    entity.Get<Velocity>() = new Velocity()
                    {
                        Value = Vector2.zero
                    };
                }
            }        }
    }
}