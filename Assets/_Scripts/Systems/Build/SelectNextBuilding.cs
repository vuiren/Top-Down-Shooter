using System.Xml.Xsl;
using Client.Components.Build;
using Client.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace _Scripts.Systems.Build
{
    public class SelectNextBuilding : IEcsRunSystem
    {
        private EcsWorld _world;
        private Configuration _configuration;
        private EcsFilter<BuildModeData> _filter;

        public void Run()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                foreach (var index in _filter)
                {
                    ref var data = ref _filter.Get1(index);
                    data.buildingIndex += 1;
                    data.buildingIndex = data.buildingIndex >= _configuration.BuildingDatas.Length
                        ? 0
                        : data.buildingIndex;
                }

                _world.NewEntity().Get<OnBuildPreviewChanged>();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                foreach (var index in _filter)
                {
                    ref var data = ref _filter.Get1(index);
                    data.buildingIndex -= 1;
                    data.buildingIndex = data.buildingIndex < 0
                        ? _configuration.BuildingDatas.Length - 1
                        : data.buildingIndex;
                }

                _world.NewEntity().Get<OnBuildPreviewChanged>();
            }
        }
    }
}