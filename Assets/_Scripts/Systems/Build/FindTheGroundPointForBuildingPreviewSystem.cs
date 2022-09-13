using Client.Components;
using Client.Components.Build;
using Client.UnityComponents;
using Client.UnityComponents.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems.Build
{
    public class FindTheGroundPointForBuildingPreviewSystem : IEcsRunSystem
    {
        private Configuration _configuration;
        private EcsFilter<BuildingPreviewFlag> _filter;
        private MousePositionService _service;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);

                var a = Physics2D.Raycast(_service.CursorPosition, Vector2.down, 10, _configuration.GroundLayers);
                if (!a) continue;
                entity.Get<GroundPoint>() = new GroundPoint()
                {
                    Value = a,
                    point = a.point
                };
            }
        }
    }
}