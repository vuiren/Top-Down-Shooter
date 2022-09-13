using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class KeepDistanceFromAttackTargetSystem : IEcsRunSystem
    {
        private EcsFilter<KeepDistanceFromAttackTargetFlag, AttackTarget> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                var position = entity.Get<Position>();
                var attackTarget = _filter.Get2(index);
                var attackTargetPosition = attackTarget.Value.Get<Position>();

                if (Vector2.Distance(position.Value, attackTargetPosition.Value) < 5f)
                {
                    Debug.Log("Check");
                    entity.Get<Velocity>() = new Velocity()
                    {
                        Value = entity.Get<Velocity>().Value + (position.Value - attackTargetPosition.Value).normalized
                    };
                }
            }
        }
    }
}