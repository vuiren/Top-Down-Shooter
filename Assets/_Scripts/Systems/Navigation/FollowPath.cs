using _Scripts.Services;
using Client.Components;
using Client.Components.Navigation;
using Leopotam.Ecs;
using UnityEngine;

namespace _Scripts.Systems.Navigation
{
    public class FollowPath : IEcsRunSystem
    {
        private INavigationService _navigationService;
        private EcsFilter<Path> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                ref var path = ref _filter.Get1(index);
                if (path.Value.Count == 0) continue;
                var pos = entity.Get<Position>();

                if (entity.Has<MoveTarget>())
                {
                    var target = entity.Get<MoveTarget>();
                    var distance = Vector2.Distance(pos.Value, target.Value);

                    if (Mathf.Approximately(distance, 0))
                    {
                        var newCell = path.Value.Dequeue();
                        entity.Get<MoveTarget>() = new MoveTarget()
                        {
                            Value = newCell.Position
                        };
                        entity.Get<Coord>() = new Coord()
                        {
                            value = newCell.CellCoords
                        };
                    }

                    continue;
                }

                if (entity.Has<Coord>())
                {
                    _navigationService.FreeCell(entity.Get<Coord>().value);
                }
                
                var newPos2 = path.Value.Dequeue();
                _navigationService.OccupyCell(newPos2.CellCoords);
                entity.Get<MoveTarget>() = new MoveTarget()
                {
                    Value = newPos2.Position
                };
                entity.Get<Coord>() = new Coord()
                {
                    value = newPos2.CellCoords
                };
            }
        }
    }
}