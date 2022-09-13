using Client.Components;
using Client.Extensions;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class AimAtAttackTarget: IEcsRunSystem
    {
        private EcsFilter<AttackTarget, BulletSpawnPoint> _filter;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                var attackTarget = _filter.Get1(index);
                var attackTargetPos = attackTarget.Value.Get<Position>().Value;
                if (attackTarget.Value.Has<AimPoint>())
                {
                    attackTargetPos = attackTarget.Value.Get<AimPoint>().Value.position.Vector2();
                }
                var point = _filter.Get2(index);

                point.Value.right = attackTargetPos - point.Value.position.Vector2();
            }
        }
    }
}