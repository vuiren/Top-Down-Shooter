using Client.Components;
using Client.UnityComponents.MonoLinks;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class LookAtAttackTargetSystem : IEcsRunSystem
    {
        private EcsFilter<GameObjectLink, AttackTarget> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                var attackTarget = _filter.Get2(index);

                if (attackTarget.Value.IsNull() || !attackTarget.Value.IsAlive()) continue;
                var attackTargetPosition = attackTarget.Value.Get<Position>();

                var entityPosition = entity.Get<Position>();
                var dir = attackTargetPosition.Value - entityPosition.Value;
                dir = dir.normalized;
                
                var gameObject = _filter.Get1(index);
                var oldRotation = gameObject.Value.transform.rotation;

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