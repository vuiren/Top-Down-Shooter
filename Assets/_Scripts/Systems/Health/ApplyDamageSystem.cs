using Client.Components;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class ApplyDamageSystem: IEcsRunSystem
    {
        private EcsFilter<TakeDamageEvent> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                var damage = _filter.Get1(index);
                
                var health = entity.Get<Health>();
                entity.Get<Health>() = new Health()
                {
                    Value = health.Value - damage.DamageCount
                };
                
                entity.Del<TakeDamageEvent>();
            }
        }
    }
}