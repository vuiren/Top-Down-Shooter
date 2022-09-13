using Client.Components;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class SelectAttackTarget// : IEcsRunSystem
    {
        /*private EcsFilter<DetectedAttackTargets> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                var attackTargets = _filter.Get1(index);

                if (entity.Has<AttackTarget>()) continue;

                entity.Get<AttackTarget>() = new AttackTarget()
                {
                    Value = attackTargets.Value[0]
                };
            }
        }*/
    }
}