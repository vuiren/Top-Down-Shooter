using System.Collections.Generic;
using _Scripts.Services;
using Client.Components;
using Client.Components.Navigation;
using Client.UnityComponents.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems.Commands
{
    public class SetPath: IEcsRunSystem
    {
        private NavigationService navigationService;
        private MousePositionService _mousePositionService;
        private EcsFilter<SelectedFlag> _filter;

        public void Run()
        {
            if(!Input.GetMouseButtonDown(1)) return;
            var cursorPosition = _mousePositionService.CursorPosition;
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                var pos = entity.Get<Position>();
                var path = navigationService.FindPath(pos.Value, cursorPosition);
                entity.Get<Path>() = new Path()
                {
                    Value = new Queue<Cell>(path)
                };
            }
        }
    }
}