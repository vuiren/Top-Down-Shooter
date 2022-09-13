using Leopotam.Ecs;
using UnityEngine;

namespace Client.Components.Build
{
    public class DestroyBuildingPreviewsSystem: IEcsRunSystem
    {
        private EcsFilter<OnBuildModeExit> _filter2;
        private EcsFilter<OnBuildPreviewChanged> _filter3;
        private EcsFilter<BuildingPreviewFlag> _filter;
        public void Run()
        {
            if(_filter2.IsEmpty() && _filter3.IsEmpty()) return;
            
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                if (entity.Has<GameObjectLink>())
                {
                    var link = entity.Get<GameObjectLink>().Value;
                    GameObject.Destroy(link);
                }
                entity.Destroy();
            }
        }
    }
}