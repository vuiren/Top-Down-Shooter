using Client.Components;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class DestroyCollisionEvent: IEcsRunSystem
    {
        private EcsFilter<OnCollisionEnterEvent> _filter;
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                entity.Del<OnCollisionEnterEvent>();
            }
        }
    }
}