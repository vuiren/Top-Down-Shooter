using Client.Components;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class DeathDetectSystem: IEcsRunSystem
    {
        private EcsFilter<Health> _filter;
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                var health = _filter.Get1(index);
                if (health.Value < 0)
                {
                    entity.Get<DeathFlag>();
                }
            }
        }
    }
}