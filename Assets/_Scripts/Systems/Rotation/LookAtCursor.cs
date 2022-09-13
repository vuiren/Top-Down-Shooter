using Client.Components;
using Client.UnityComponents.Services;
using Leopotam.Ecs;

namespace Client.Systems.Rotation
{
    public class LookAtCursor : IEcsRunSystem
    {
        private readonly EcsFilter<GameObjectLink, LookAtCursorFlag> _filter;

        private MousePositionService _mousePositionService;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                var cursorPosition = _mousePositionService.CursorPosition;

                var entityPosition = entity.Get<Position>();
                var dir = cursorPosition - entityPosition.Value;
                dir = dir.normalized;

                var gameObject = _filter.Get1(index);
                var oldRotation = gameObject.Value.transform.rotation;
                // gameObject.Value.transform.rotation = Quaternion.Euler(0, dir.x > 0 ? 0 : 180f, 0);
                gameObject.Value.transform.up = dir;

                entity.Get<Components.Rotation>() = new Components.Rotation()
                {
                    Value = gameObject.Value.transform.rotation
                };
                gameObject.Value.transform.rotation = oldRotation;
            }
        }
    }
}