using Client.Components;
using Client.Components.Build;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems.Build
{
    public class StickBuildingPreviewToTheGroundSystem: IEcsRunSystem
    {
        private EcsFilter<BuildingPreviewFlag, GroundPoint> _filter;
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                var groundPoint = _filter.Get2(index);

                entity.Get<Position>() = new Position()
                {
                    Value = groundPoint.point
                };
            }
        }
    }
}