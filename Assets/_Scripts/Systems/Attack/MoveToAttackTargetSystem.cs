using System.Collections.Generic;
using _Scripts.Services;
using Client.Components;
using Client.Components.Navigation;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class MoveToAttackTargetSystem : IEcsRunSystem
    {
        private EcsFilter<AttackTarget, Position, FollowingAttackTargetFlag> _filter;
        private NavigationService navigationService;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);

                var attackTarget = _filter.Get1(index);
                if (!attackTarget.Value.IsAlive()) return;

                var entityPosition = _filter.Get2(index);
                var attackTargetPosition = attackTarget.Value.Get<Position>();
                var pos = _filter.Get2(index);
                var path = navigationService.FindPath(pos.Value, attackTargetPosition.Value);
                entity.Get<Path>() = new Path()
                {
                    Value = new Queue<Cell>(path)
                };
                
                /*var direction = attackTargetPosition.Value - entityPosition.Value;
                entity.Get<Velocity>() = new Velocity()
                {
                    Value = direction.normalized
                };*/
            }
        }
    }
}