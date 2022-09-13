using Client.Components;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class PreventOnAttackTargetDetectedDoublingEvent: IEcsRunSystem
    {
        private EcsFilter<OnAttackTargetDetected> _filter;
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);

                if (entity.Has<AttackTarget>() && entity.Get<AttackTarget>().Value.IsAlive())
                {
                    entity.Del<OnAttackTargetDetected>();
                    continue;
                }
            }
        }
    }
}