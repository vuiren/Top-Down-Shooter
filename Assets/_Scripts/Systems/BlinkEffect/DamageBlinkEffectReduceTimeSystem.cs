using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class DamageBlinkEffectReduceTimeSystem : IEcsRunSystem
    {
        private EcsFilter<DamageBlinkEffect> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                ref var effect = ref _filter.Get1(index);

                effect = new DamageBlinkEffect()
                {
                    RemainingTime = effect.RemainingTime - Time.deltaTime
                };

                if (effect.RemainingTime < 0)
                {
                    entity.Del<DamageBlinkEffect>();
                }
            }
        }
    }
}