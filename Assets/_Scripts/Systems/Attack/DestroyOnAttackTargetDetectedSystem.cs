using Client.Components;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class DestroyOnAttackTargetDetectedSystem: IEcsRunSystem
    {
        private EcsFilter<OnAttackTargetDetected> _filter;
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                entity.Del<OnAttackTargetDetected>();
            }
        }
    }
}