using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class FollowAttackTargetSystem: IEcsRunSystem
    {
        private EcsFilter<AttackTarget, Position, AttackStartDistance> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);

                var attackTarget = _filter.Get1(index);
                if(!attackTarget.Value.IsAlive()) return;
                
                var entityPosition = _filter.Get2(index);
                var attackTargetPosition = attackTarget.Value.Get<Position>();
                var distance = Vector2.Distance(entityPosition.Value, attackTargetPosition.Value);

                var attackStartDistance = _filter.Get3(index);
                
                if (!(distance > attackStartDistance.Value)) continue;

                entity.Get<FollowingAttackTargetFlag>();
            }            
        }
    }
}