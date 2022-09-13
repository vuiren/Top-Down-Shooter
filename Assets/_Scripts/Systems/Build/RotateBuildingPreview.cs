using Client.Components;
using Client.Components.Build;
using Leopotam.Ecs;
using UnityEngine;

namespace _Scripts.Systems.Build
{
    public class RotateBuildingPreview : IEcsRunSystem
    {
        private EcsFilter<BuildingPreviewFlag> _filter;

        public void Run()
        {
            if(!Input.GetMouseButtonDown(1)) return;
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);

                var rotation = entity.Get<Rotation>();

                entity.Get<Rotation>() = new Rotation()
                {
                    Value = Quaternion.Euler(0, rotation.Value.y < 180 ? 180 : 0, 0)
                };
            }
        }
    }
}