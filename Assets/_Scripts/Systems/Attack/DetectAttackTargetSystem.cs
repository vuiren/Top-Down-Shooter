using Client.Components;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class DetectAttackTargetSystem : IEcsRunSystem
    {
        private EcsFilter<OnAttackTargetDetected> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                if(entity.Has<AttackTarget>() && entity.Get<AttackTarget>().Value.IsAlive()) continue;
                var onAttackTargetDetected = _filter.Get1(index);

                entity.Get<AttackTarget>() = new AttackTarget()
                {
                    Value = onAttackTargetDetected.DetectedTarget
                };
            }
        }
    }
}