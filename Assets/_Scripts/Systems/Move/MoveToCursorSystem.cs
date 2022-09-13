using Client.Components;
using Client.UnityComponents.Services;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class MoveToCursorSystem: IEcsRunSystem
    {
        private MousePositionService _mousePositionService;
        private EcsFilter<FollowingCursorFlag> _filter;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                entity.Get<MoveTarget>() = new MoveTarget()
                {
                    Value = _mousePositionService.CursorPosition
                };
            }
        }
    }
}