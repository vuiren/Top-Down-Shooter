using System.Linq;
using Client.Components;
using Leopotam.Ecs;

namespace Client.Systems
{
    public struct DestroyEmptyDetectedAttackTargetsSystem : IEcsRunSystem
    {
        private EcsFilter<AttackTarget> _filter2;

        public void Run()
        {
            foreach (var index in _filter2)
            {
                ref var entity = ref _filter2.GetEntity(index);
                var attackTarget = _filter2.Get1(index);
                if (!attackTarget.Value.IsAlive())
                {
                    entity.Del<AttackTarget>();
                }
            }
        }
    }
}