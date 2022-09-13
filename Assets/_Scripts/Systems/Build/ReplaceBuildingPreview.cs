using Client.Components;
using Client.Components.Build;
using Client.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace _Scripts.Systems.Build
{
    public class ReplaceBuildingPreview : IEcsRunSystem
    {
        private EcsWorld _world;
        private Configuration _configuration;
        private EcsFilter<OnBuildPreviewChanged> _filter;
        private EcsFilter<BuildModeData> _filter2;

        public void Run()
        {
            if (_filter.IsEmpty()) return;

            var buildData = new BuildModeData();

            foreach (var index in _filter2)
            {
                buildData = _filter2.Get1(index);
            }
            
            var prefab = _configuration.BuildingDatas[buildData.buildingIndex].previewBuildingPrefab;

            _world.NewEntity().Get<SpawnPrefab>() = new SpawnPrefab()
            {
                Position = Vector2.zero,
                Prefab = prefab
            };
        }
    }
}