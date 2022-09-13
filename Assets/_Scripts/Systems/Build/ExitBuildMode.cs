using Client.Components.Build;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems.Build
{
    public class ExitBuildMode: IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<BuildingPreviewFlag> _filter;
        public void Run()
        {
            if(_filter.IsEmpty()) return;

            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("Exiting build mode");
                _world.NewEntity().Get<OnBuildModeExit>();
            }
        }
    }
}