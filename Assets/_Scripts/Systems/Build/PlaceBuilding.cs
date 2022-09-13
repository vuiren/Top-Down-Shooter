using System.Linq;
using Client.Components;
using Client.Components.Build;
using Client.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace _Scripts.Systems.Build
{
    public class PlaceBuilding : IEcsRunSystem
    {
        private Configuration _configuration;
        private EcsWorld _world;
        private EcsFilter<BuildingPreviewFlag, BuildingType> _filter;

        public void Run()
        {
            if (!Input.GetKeyDown(KeyCode.E)) return;

            foreach (var index in _filter)
            {
                var entity = _filter.GetEntity(index);

                var buildingType = _filter.Get2(index);
                var buildingData = _configuration.BuildingDatas.FirstOrDefault(x => x.buildingTypes == buildingType.Value);
                if (!buildingData.buildingPrefab) continue;

                var position = entity.Get<Position>();

                _world.NewEntity().Get<SpawnPrefab>() = new SpawnPrefab()
                {
                    Position = position.Value,
                    Prefab = buildingData.buildingPrefab,
                };
            }
        }
    }
}