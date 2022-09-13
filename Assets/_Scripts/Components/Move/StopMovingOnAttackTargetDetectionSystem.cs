using Leopotam.Ecs;
using UnityEngine;

namespace Client.Components
{
    public class StopMovingOnAttackTargetDetectionSystem: IEcsRunSystem
    {
        private EcsFilter<OnAttackTargetDetected, MoveTarget> _filter;
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                Debug.Log("Check");
                entity.Del<MoveTarget>();
                entity.Get<Velocity>() = new Velocity()
                {
                    Value = Vector2.zero
                };
            }
        }
    }
}