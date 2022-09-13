using Client.Components.Build;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems.Build
{
    public class EnterBuildModeSystem : IEcsRunSystem
    {
        private EcsFilter<BuildingPreviewFlag> _filter;
        private EcsWorld _world;

        public void Run()
        {
            if (!_filter.IsEmpty()) return;
            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("Entering build mode");
                _world.NewEntity().Get<OnBuildModeEnter>();
                _world.NewEntity().Get<BuildModeData>();
            }
        }
    }
}