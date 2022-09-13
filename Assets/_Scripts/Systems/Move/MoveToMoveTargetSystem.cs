using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class MoveToMoveTargetSystem: IEcsRunSystem
    {
        private EcsFilter<MoveTarget, Position> _filter;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                var position = _filter.Get2(index);
                var movePosition = _filter.Get1(index);
                entity.Get<Velocity>() = new Velocity()
                {
                    Value = (movePosition.Value - position.Value).normalized
                };
            }    
        }
    }
}