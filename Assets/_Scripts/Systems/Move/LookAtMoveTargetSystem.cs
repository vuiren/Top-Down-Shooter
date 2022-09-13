using Client.Components;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class LookAtMoveTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GameObjectLink, MoveTarget, LookAtMoveTargetFlag> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                var moveTarget = _filter.Get2(index);

                var entityPosition = entity.Get<Position>();
                var dir = moveTarget.Value - entityPosition.Value;
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