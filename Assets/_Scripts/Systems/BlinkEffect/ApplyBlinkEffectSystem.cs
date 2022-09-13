using Client.Components;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class ApplyBlinkEffectSystem : IEcsRunSystem
    {
        private EcsFilter<TakeDamageEvent> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                if (entity.Has<DamageBlinkEffect>()) continue;
                entity.Get<DamageBlinkEffect>() = new DamageBlinkEffect()
                {
                    RemainingTime = 2f
                };
            }
        }
    }
}