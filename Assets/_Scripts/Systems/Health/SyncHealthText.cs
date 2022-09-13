using Client.Components;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class SyncHealthText: IEcsRunSystem
    {
        private EcsFilter<Health, HealthText, TakeDamageEvent> _filter;
        public void Run()
        {
            foreach (var index in _filter)
            {
                var health = _filter.Get1(index);
                var healthText = _filter.Get2(index);
                healthText.Value.text = health.Value.ToString();
            }
        }
    }
}