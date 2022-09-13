using Client.Components.Navigation;
using Leopotam.Ecs;

namespace Client.Systems.Commands
{
    public class RemoveEmptyPath: IEcsRunSystem
    {
        private EcsFilter<Path> _filter;
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                var path = _filter.Get1(index);
                if (path.Value.Count == 0)
                {
                    entity.Del<Path>();
                }
            }
        }
    }
}