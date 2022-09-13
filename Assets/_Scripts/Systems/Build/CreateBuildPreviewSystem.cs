using Client.Components;
using Client.Components.Build;
using Client.UnityComponents;
using Leopotam.Ecs;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Client.Systems.Build
{
    public class CreateBuildPreviewSystem : IEcsRunSystem
    {
        private Configuration configuration;
        private EcsWorld _world;
        private EcsFilter<OnBuildModeEnter> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                var entity = _world.NewEntity();
                entity.Get<BuildingPreviewFlag>();
                entity.Get<SpawnPrefab>() = new SpawnPrefab()
                {
                    Parent = null,
                    Position = Vector2.zero,
                    Rotation = Quaternion.Euler(0,0,0),
                    Prefab =  configuration.BuildingDatas[0].previewBuildingPrefab
                };
            }
        }
    }
}