using Client.Components.Build;
using Leopotam.Ecs;

namespace Client.Systems.Build
{
    public class UpdateBuildingPreviewStateSystem: IEcsRunSystem
    {
        private EcsFilter<BuildingPreviewFlag> _filter;
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                
                 
            }
        }
    }
}